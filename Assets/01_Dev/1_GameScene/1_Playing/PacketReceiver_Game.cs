using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.SceneManagement;

public class PacketReceiver_Game : MonoBehaviour {

    Queue<IEnumerator> eventQueue = new Queue<IEnumerator>();

    private void Start() {

        ServerData.InitializeDataObjects();

        Add_Render();
        Add_SkillResult();
        Add_Refresh();
        Add_Dead();
        Add_ChangeCat();
        Add_Ban();
        Add_GameResult();

    }

    // Listeners

    JObject jObject;

    private void Add_Render() { // 게임 씬 로드될 때

        ServerData.socket.On("render", (data) => {

            jObject = JObject.Parse(data);
            
            Debug.Log(jObject["userList"]);

            // ServerData 조지기

            ServerData.gameId = jObject["gameId"].ToObject<string>();
            ServerData.timer = jObject["timer"].ToObject<int>();
            ServerData.blocks = jObject["map"].ToObject<Block[][]>();
            MyClientData.id=jObject["socketId"].ToObject<string>();

            Dictionary<string, JObject> usersList = jObject["userList"].ToObject<Dictionary<string, JObject>>();
            foreach(KeyValuePair<string, JObject> userPair in usersList) {
                Debug.Log(userPair.Value.ToString());
                string tempid=userPair.Value["id"].ToObject<string>();
                if(MyClientData.id.Equals(tempid)){
                    MyClientData.nickname=userPair.Value["nickname"].ToObject<string>();
                    MyClientData.userType=userPair.Value["type"].ToObject<UserType>();
                }
                switch(userPair.Value["type"].ToObject<UserType>()) {
                    case UserType.CAT :
                        ServerData.cat = userPair.Value.ToObject<Cat>(); // cat 할당
                        break;
                    case UserType.BUG :
                        Bug bug = userPair.Value.ToObject<Bug>();
                        ServerData.bugs.Add(bug.id, bug); // bugs 할당
                        break;
                }
            }
        });
        // 렌더링하기
            Debug.Log(MyClientData.id);
            GameRenderer gameRenderer = this.GetComponent<GameRenderer>();
            gameRenderer.Render();

            this.GetComponent<CameraWork>().setCamera();

    }

    // 패킷 없음! //
    private void Add_GameStart() {
        ServerData.socket.On("game_start", () => {
            // TODO 클라이언트 조작가능하게 변경 : 스크립트 컴포넌트 SetActive
        });
    }

    private void Add_SkillResult() {
        ServerData.socket.On("skill_result", (data) => {

            jObject = JObject.Parse(data);
            Debug.Log(jObject[""]);

        });
    }

    private void Add_Refresh() {
        ServerData.socket.On("refresh", (data) => {

            // TODO Move 코루틴 호출
            // TODO ServerData 갱신
            // TODO timer, minimap, score 등 UI 갱신

            jObject = JObject.Parse(data);

            // ServerData 조지기
            ServerData.timer = jObject["timer"].ToObject<int>();
            ServerData.blocks = jObject["map"].ToObject<Block[][]>();

            // 움직일거 움직이기
            Dictionary<string, JObject> animationDict = jObject["animationList"].ToObject<Dictionary<string,JObject>>();
            foreach(KeyValuePair<string, JObject> animationPair in animationDict) {

                string id = animationPair.Key;
                Direction dir = animationPair.Value["direction"].ToObject<Direction>();
                Position pos = animationPair.Value["position"].ToObject<Position>();

                GameObject movingObject;
                InGameData.bugObjectsDict.TryGetValue(id, out movingObject);

                MoveManager moveManager = this.GetComponent<MoveManager>();
                moveManager.movePlayer(movingObject, dir);
            }

        });
    }

    private void Add_Dead() {
        ServerData.socket.On("dead", (data) => {

            Debug.Log(data);
            jObject = JObject.Parse(data);
            // TODO 죽어서 창 띄우기
        });
    }

    private void Add_ChangeCat() {
        ServerData.socket.On("change_cat", (data) => {

            Debug.Log(data);
            jObject = JObject.Parse(data);
            // TODO MyClientData 갱신, CameraPivot을 MyClient.myObject의 위치로 이동
        });
    }

    private void Add_Ban() {
        ServerData.socket.On("ban", (data) => {

            Debug.Log(data);
            jObject = JObject.Parse(data);
            // TODO 해당 유저 파괴하기 (본인 클라이언트의 유저라면 시작화면으로)
        });
    }

    private void Add_GameResult() {
        ServerData.socket.On("game_result", (data) => {

            Debug.Log(data);
            jObject = JObject.Parse(data);
            // TODO GameResult 창 띄우기
        });
    }

}