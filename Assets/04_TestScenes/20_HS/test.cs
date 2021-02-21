using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

   private Animator anim;

   [SerializeField] private float scratch;

   private bool isStretch;
   private bool isScratching;
   private bool isScratch;
   private bool isReturn;

   void Start () {
      anim = GetComponent<Animator>();
   }

   void Update () {
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