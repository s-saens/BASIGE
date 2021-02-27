using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWork : MonoBehaviour
{
   Vector3 destPos;
   public Transform camPivot;
   bool camIsActive = false;

    // Start is called before the first frame update
    public void SetCamera()
    {

        // 내꺼 아이디를 통해 위치 찾고, 카메라 이동시킬 좌표를 그 위치로 지정
        string myClientId = ServerData.myClient.id;
        destPos = InGameData.userObjects[myClientId].transform.position;

        //먼저 카메라 피벗을 내 유저 위치(destPos)로 순간이동!
        camPivot.position = destPos;

        // 타입에 따라 카메라 크기 조정

        int camOrthoSize = 5;

        switch(ServerData.myClient.type) {
            case UserType.CAT :
                camOrthoSize=8;
                break;
            case UserType.BUG :
                camOrthoSize=5;
                break;
        }

        Camera cam = camPivot.GetChild(0).GetComponent<Camera>();
        cam.orthographicSize = camOrthoSize;

        camIsActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!camIsActive) return;
        
        Vector3 pre = camPivot.position;
        camPivot.position=Vector3.Lerp(pre, destPos, 3 * Time.deltaTime);
    }
}
