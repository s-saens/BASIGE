﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{

    public FixedJoystick joystick;
    public GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
    }

    void FixedUpdate()
    {
        float dirx = joystick.Horizontal;
        float dirz = joystick.Vertical;
        Vector3 direction = new Vector3(joystick.Horizontal, 0, joystick.Vertical);

        if (direction != Vector3.zero)
        {
           Direction dir=0;
           float deadZone = 0.1f;
           if (dirx > deadZone && dirz > deadZone) dir=Direction.UP;
           if (dirx < -deadZone && dirz < -deadZone) dir=Direction.DOWN;
           if (dirx < -deadZone && dirz > deadZone) dir=Direction.LEFT;
           if (dirx > deadZone && dirz < -deadZone) dir=Direction.RIGHT;           
           ServerHandler.socket.Emit("move","{gameId : " + ClientData.id + ", directon : "+ dir.ToString() + " }");
        }
    }
}
