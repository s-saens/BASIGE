using UnityEngine;
using System.Collections;

public class Test2 : MonoBehaviour
{

  private Animation anim;

  void Starts()
  {
    anim = GetComponent<Animation>();
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      GetComponent<Animation>().Play("Scratch");
    }
  }
}
