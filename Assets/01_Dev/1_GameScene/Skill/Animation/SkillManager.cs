using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
 
public class SkillManager : MonoBehaviour 
{
    public Animation animation;
    public Image skillFilter;
    public Text scratch_coolTimeText; //남은 쿨타임을 표시할 텍스트
    public Text boost_coolTimeText;

    private Dictionary<string, Skill> skills = ServerData.cat.skills;
 
    void start()
    {
        skillFilter.fillAmount = 0; //처음에 스킬 버튼을 가리지 않음
    }
 
    public void SendSkillPacket(string skillName) { // 버튼 누르면 실행됨

        if(CanUseSkill(skillName)) {

            JObject jObject = new JObject();
            jObject.Add("gameId", ServerData.gameId);
            jObject.Add("skill", skillName);

            ServerData.socket.Emit(jObject.ToString());

        }
    }

    public void UseSkill(string skillName) // 패킷 받으면 실행됨
    {
        Debug.Log("Use Skill");
        skillFilter.fillAmount = 1; //스킬 버튼을 보여줌

        switch (skillName) {
            case "scratch" :
                animation.Play("Scratch");
                break;
            case "boost" :
                break;
        }

        scratch_coolTimeText.text = "" + skills[skillName].coolProcess;
        skills[skillName].coolProcess = 600;
    }

    private bool CanUseSkill(string skillName) {

        return skills[skillName].coolProcess <= 0 ; // 쿨타임이 0이면 스킬 쓸 수 있음

    }
}