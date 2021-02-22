using UnityEngine;
using System.Collections;

public class Test2 : MonoBehaviour {
   private Animator anim;
   [SerializeField] private float scratch;
   private bool isStretch;
   private bool isScratching;
   private bool isScratch;
   private bool isReturn;

   private void Start() {
      anim = GetComponent<Animator>();
   }

   private void Update() {
      TryScratch();
   }

   private void TryScratch() {
      if(Input.GetKeyDown(KeyCode.Space) && !isStretch)
      {
         isStretch = true;
         anim.SetTrigger("Scratch");
      }
   }
}
