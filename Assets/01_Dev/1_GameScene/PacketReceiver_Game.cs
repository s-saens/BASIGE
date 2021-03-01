using UnityEngine;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine.SceneManagement;

public class PacketReceiver_Game : MonoBehaviour {

    MoveManager moveManager;

    private void Start() {

        moveManager = this.GetComponent<MoveManager>();

        ServerData.InitializeDataObjects();
        AddListeners();

    }

    private void AddListeners() {

        Add_Render();
        Add_SkillResult();
        Add_GameStart();
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
            Block[][] blocks = jObject["map"].ToObject<Block[][]>();


            string socketId = jObject["socketId"].ToObject<string>(); // myId
            Debug.Log("Matched successfully! socket id is : " + socketId);

            Dictionary<string, User> usersList = jObject["userList"].ToObject<Dictionary<string,User>>();

            // Client only 속성 초기화
            foreach(KeyValuePair<string, User> userPair in usersList) {
                userPair.Value.isMoving = false;
                userPair.Value.cQueue = new CoroutineQueue(1000000, StartCoroutine);
                if(userPair.Value.type == UserType.CAT) {
                    ServerData.cat = userPair.Value.ConvertToCat();
                }
            }

            // 서버의 usersList와 클라이언트의 ServerData.users 동기화
            ServerData.users = usersList;
            // myClient!
            ServerData.myClient = ServerData.users[socketId];

            // 렌더링하고 카메라 세팅
            this.GetComponent<GameRenderer>().Render();
            this.GetComponent<CameraWork>().SetCamera();

        });

    }

    // 패킷 없음! //
    private void Add_GameStart() {
        ServerData.socket.On("game_start", (data) => {

            // MoveManager Activate
            moveManager.isActive = JObject.Parse(data)["start"].ToObject<bool>();

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
            
            jObject = JObject.Parse(data);

            ///// ServerData 조지기 /////
            ServerData.timer = jObject["timer"].ToObject<int>();

            Debug.Log("refreshed : \n" + jObject["map"].ToString());

            ///// 블록 업데이트 /////
            List<JObject> differedBlockList = jObject["map"].ToObject<List<JObject>>();
            
            foreach(JObject differed in differedBlockList) {

                Position blockPos = differed["position"].ToObject<Position>();
                Block differedBlock = differed["block"].ToObject<Block>();
                ServerData.blocks[blockPos.y][blockPos.x] = differedBlock;
                InGameData.UpdateBlocks(blockPos);

            }
            

            ///// 움직일거 움직이기 - 유저 /////
            Dictionary<string, JObject> animationDict = jObject["animationList"].ToObject<Dictionary<string,JObject>>();
            foreach(KeyValuePair<string, JObject> animationPair in animationDict) {

                string id = animationPair.Key;

                Direction dir = animationPair.Value["direction"].ToObject<Direction>();
                Position pos = animationPair.Value["position"].ToObject<Position>(); // 이건 무결성 점검용?

                User movingUser = ServerData.users[id];
                
                if(movingUser.position.Equals(pos))

                movingUser.cQueue.Run(moveManager.Move(movingUser, dir));

            }

            ///// 스킬 쓰기 -  /////
            ServerData.cat = jObject["cat"].ToObject<Cat>();
            // 버튼의 쿨타임 갱신
            SkillManager skillManager = this.GetComponent<SkillManager>();
            skillManager.

        });
    }

    private void Add_Dead() {
        ServerData.socket.On("dead", (data) => {

            Debug.Log(data);
            jObject = JObject.Parse(data);
            
            ///// 오브젝트 파괘! /////
            string deadUserId = jObject["id"].ToObject<string[]>()[0];
            // 1) 실제 게임오브젝트 인스턴스 삭제 
            Destroy(InGameData.userObjects[deadUserId]);
            // 2) InGameData, ServerData에서 삭제
            InGameData.userObjects.Remove(deadUserId);
            ServerData.users.Remove(deadUserId);


        });
    }

    private void Add_ChangeCat() {
        ServerData.socket.On("change_cat", (data) => {

            Debug.Log(data);
            jObject = JObject.Parse(data);

            ServerData.cat = ServerData.users[jObject["id"].ToObject<string>()].ConvertToCat();

        });
    }

    private void Add_Ban() {
        ServerData.socket.On("ban", (data) => {

            Debug.Log(data);
            jObject = JObject.Parse(data);

        });
    }

    private void Add_GameResult() {
        ServerData.socket.On("game_result", (data) => {

            Debug.Log(data);
            jObject = JObject.Parse(data);
            string winner=jObject["winner"].ToObject<string>();
            int catScore=jObject["catScore"].ToObject<int>();
            int bugScore=jObject["bugScore"].ToObject<int>();
            
            // GameResult 창 띄우기
            SceneManager.LoadScene(2);
            GameResult gameResult=this.GetComponent<GameResult>();
            gameResult.setText(winner,catScore,bugScore);
            
        });
    }

}