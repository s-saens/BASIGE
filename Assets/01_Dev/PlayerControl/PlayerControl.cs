using UnityEngine;

//Simple Controller

public class PlayerControl : MonoBehaviour
{
    public Joystick joystick;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        player.transform.Translate(player.transform.forward * joystick.Vertical * Time.deltaTime * 10);
        player.transform.Translate(player.transform.right * joystick.Horizontal * Time.deltaTime * 10);
    }
}
