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

            // ServerData 조지기

            ServerData.gameId = jObject["gameId"].ToObject<string>();
            ServerData.timer = jObject["timer"].ToObject<int>();
            ServerData.blocks = jObject["map"].ToObject<Block[][]>();

            string socketId = jObject["socketId"].ToObject<string>();
            Debug.Log("Matched successfully! game id is : " + socketId);

            Dictionary<string, User> usersList = jObject["userList"].ToObject<Dictionary<string,User>>();
            foreach(KeyValuePair<string, User> userPair in usersList) {

                userPair.Value.isMoving = false; // isMoving은 클라의 User에만 있음
                // (이 유저의 아이디 == 내 소켓의 아이디) 내클라이언트(myClient)에 넣어주기
                if(socketId == userPair.Value.id) {
                    ServerData.myClient = userPair.Value;
                    Debug.Log(ServerData.myClient.isMoving);
                }
            }

            // 서버의 usersList와 클라이언트의 ServerData.users 동기화
            ServerData.users = usersList;


            // 렌더링하고 카메라 세팅
            this.GetComponent<GameRenderer>().Render();
            this.GetComponent<CameraWork>().SetCamera();

        });

    }

    // 패킷 없음! //
    private void Add_GameStart() {
        ServerData.socket.On("game_start", () => {

            // MoveManager Activate
            MoveManager moveManager = this.GetComponent<MoveManager>();
            moveManager.isActive = true;

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
            
            Debug.Log("refreshed");

            jObject = JObject.Parse(data);

            // ServerData 조지기
            ServerData.timer = jObject["timer"].ToObject<int>();
            ServerData.blocks = jObject["map"].ToObject<Block[][]>();

            // 움직일거 움직이기
            Dictionary<string, JObject> animationDict = jObject["animationList"].ToObject<Dictionary<string,JObject>>();
            foreach(KeyValuePair<string, JObject> animationPair in animationDict) {

                string id = animationPair.Key;

                Direction dir = animationPair.Value["direction"].ToObject<Direction>();
                Position pos = animationPair.Value["position"].ToObject<Position>(); // 이건 무결성 점검용?

                User movingUser = ServerData.users[id];
                
                MoveManager moveManager = this.GetComponent<MoveManager>();
                StartCoroutine(moveManager.Move(movingUser, dir));

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
            string winner=jObject["winner"].ToObject<string>();
            int catScore=jObject["catScore"].ToObject<int>();
            int bugScore=jObject["bugScore"].ToObject<int>();
            // TODO GameResult 창 띄우기
            SceneManager.LoadScene(2);
            GameResult gameResult=this.GetComponent<GameResult>();
            gameResult.setText(winner,catScore,bugScore);
        });
    }

}