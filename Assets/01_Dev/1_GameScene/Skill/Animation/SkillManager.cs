using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Newtonsoft.Json.Linq;
 
public class SkillManager : MonoBehaviour 
{
    public Image[] skillFilter = new Image[2]; // 쿨타임을 시각화하는 필터
    private Text[] coolTimeText = new Text[2]; //남은 쿨타임을 표시할 텍스트

    public Animation anim;

    [HideInInspector]
    public int[] coolTime = new int[2]; // 총 쿨타임 (초)
    [HideInInspector]
    public int[] currentCoolTime = new int[2]; //남은 쿨타임을 추적 할 변수
    [HideInInspector]
    public bool[] canUseSkill = new bool[2] {true, true}; //스킬을 사용할 수 있는지 확인하는 변수
 
    void start()
    {
        coolTime[0] = 30; // boost 쿨타임 (초)
        coolTime[1] = 30; // scratch 쿨타임
        currentCoolTime[0] = 0;
        currentCoolTime[1] = 0;
        coolTimeText[0] = skillFilter[0].transform.GetChild(0).GetComponent<Text>();
        coolTimeText[1] = skillFilter[1].transform.GetChild(0).GetComponent<Text>();
        skillFilter[0].fillAmount = 0; //처음에 스킬 버튼을 가리지 않음
        skillFilter[1].fillAmount = 0; //처음에 스킬 버튼을 가리지 않음
    }
 
    public void UseSkill(SkillType skillType)
    {
        if (canUseSkill[(int)skillType])
        {
            skillFilter[(int)skillType].fillAmount = 1; //스킬 버튼을 가림
            StartCoroutine(Cooltime(skillType));
 
            currentCoolTime[(int)skillType] = coolTime[(int)skillType] + 1;
            coolTimeText[(int)skillType].text = "" + currentCoolTime;

            StartCoroutine(CoolTimeCounter(skillType));
 
            canUseSkill[(int)skillType] = false; //스킬을 사용하면 사용할 수 없는 상태로 바꿈
        }
        else
        {
            Debug.Log("아직 스킬을 사용할 수 없습니다.");
        }

        if( skillType == SkillType.SCRATCH ) {

            ServerData.users[ServerData.catId].cQueue.Run(anim.GetEnumerator());

        }
        
    }

    IEnumerator Cooltime(SkillType skillType)
    {
        while(skillFilter[(int)skillType].fillAmount > 0)
        {
            // 쿨타임 비율만큼 버튼을 가림
            skillFilter[(int)skillType].fillAmount -= 1 * Time.smoothDeltaTime / coolTime[0];
            int vel = 1;

            switch(skillType) {

                case SkillType.BOOST :
                    if(currentCoolTime[(int)skillType] < 0.5f) vel = 2;
                    else vel = 1;
                    ServerData.users[ServerData.catId].velocity = vel;
                    break;

                case SkillType.SCRATCH :
                    // nothing
                    break;

            }
 
            yield return 0;
        }
 
        canUseSkill[(int)skillType] = true; //스킬 쿨타임이 끝나면 스킬을 사용할 수 있는 상태로 바꿈
        yield break;
    }
 
    //남은 쿨타임을 계산할 코르틴을 만들어줍니다.
    IEnumerator CoolTimeCounter(SkillType skillType)
    {
        while(currentCoolTime[(int)skillType] > 0)
        {
            yield return new WaitForSeconds(1.0f);
            currentCoolTime[(int)skillType] -= 1;
            coolTimeText[(int)skillType].text = "" + currentCoolTime[(int)skillType];
        }
    }

    public void SendSkillPacket(SkillType skillType) {
        
        JObject jObject = new JObject();

        string skillName="";

        if(canUseSkill[(int)skillType]) {

            switch(skillType) {

                case SkillType.BOOST :
                    skillName = "boost";
                    break;

                case SkillType.SCRATCH :
                    skillName = "scratch";
                    break;
            }

        }
        jObject.Add(ServerData.gameId);
        jObject.Add("skill", skillName);

        ServerData.socket.EmitJson("skill", jObject.ToString());
    }

}