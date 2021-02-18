using UnityEngine;
using System.Collections;

public class SkillManager : MonoBehaviour {

   public void DoSkill(Cat cat, string skillName, GameObject catObj) {
      Skill skill;
      cat.skills.TryGetValue("skillName", out skill);

      StartCoroutine(skill.skillAnimation(catObj));
   }

}