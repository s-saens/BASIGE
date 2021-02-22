using UnityEngine;
using System.Collections;

public abstract class Skill {

   public string name;
   public int coolTime;
   public int coolProcess;

   public abstract bool CanUseSkill();
   public abstract IEnumerator skillAnimation(GameObject obj);

}

public class Scratch : Skill {

   public override IEnumerator skillAnimation(GameObject obj) {
      // GameObject 앞발 = obj.transform.GetChild(0).gameObject;
      yield return 0;
   }

   public override bool CanUseSkill() {
      return false;
   }

}