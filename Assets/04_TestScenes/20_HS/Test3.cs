using UnityEngine;
using UnityEngine.UI;
using System.Collections;
 
public class Test3 : MonoBehaviour 
{
    public Image skillFilter;
    public Text coolTimeCounter; //남은 쿨타임을 표시할 텍스트
 
    public float coolTime;
 
    private float currentCoolTime; //남은 쿨타임을 추적 할 변수
 
    private bool canUseSkill = true; //스킬을 사용할 수 있는지 확인하는 변수
 
    void start()
    {
        skillFilter.fillAmount = 0; //처음에 스킬 버튼을 가리지 않음
    }
 
    public void UseSkill()
    {
        if (canUseSkill)
        {
            Debug.Log("Use Skill");
            skillFilter.fillAmount = 1; //스킬 버튼을 가림
            StartCoroutine("Cooltime");
 
            currentCoolTime = coolTime;
            coolTimeCounter.text = "" + currentCoolTime;
 
            StartCoroutine("CoolTimeCounter");
 
            canUseSkill = false; //스킬을 사용하면 사용할 수 없는 상태로 바꿈
        }
        else
        {
            Debug.Log("아직 스킬을 사용할 수 없습니다.");
        }
    }
 
    IEnumerator Cooltime()
    {
        while(skillFilter.fillAmount > 0)
        {
            skillFilter.fillAmount -= 1 * Time.smoothDeltaTime / coolTime;
 
            yield return null;
        }
 
        canUseSkill = true; //스킬 쿨타임이 끝나면 스킬을 사용할 수 있는 상태로 바꿈
 
        yield break;
    }
 
    //남은 쿨타임을 계산할 코르틴을 만들어줍니다.
    IEnumerator CoolTimeCounter()
    {
        while(currentCoolTime > 0)
        {
            yield return new WaitForSeconds(1.0f);
 
            currentCoolTime -= 1.0f;
            coolTimeCounter.text = "" + currentCoolTime;
        }
 
        yield break;
    }
}