using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

   private void Start() {

      
      if(true) {
         
         StartCoroutine(asd());
         
      }

   }

   IEnumerator asd() {
      for(int i=0 ; i<100 ; ++i) {
         this.transform.Translate(this.transform.forward * Time.deltaTime);
         yield return 0;
      }
   }

}