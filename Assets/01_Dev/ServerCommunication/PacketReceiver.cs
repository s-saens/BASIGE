using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class PacketReceiver : MonoBehaviour {
   
    Queue<IEnumerator> eventQueue = new Queue<IEnumerator>();

    public void AddAllListeners() {
        Add_MatchStatus();
        Add_Render();
        Add_SkillResult();
        Add_Refresh();
        Add_Dead();
        Add_ChangeCat();
        Add_Ban();
        Add_GameResult();
    }

    // Listeners

    private void Add_MatchStatus() {
        ServerHandler.socket.On("match_status", (string data) => {
            
        });
    }

    private void Add_Render() {

        GameRenderer gameRenderer = this.GetComponent<GameRenderer>();
        

    }

    // 패킷 없음! //
    private void Add_GameStart() {
        ServerHandler.socket.On("game_start", (string data) => {
            // TODO 클라이언트 조작가능하게 변경
        });
    }

    private void Add_SkillResult() {
        ServerHandler.socket.On("skill_result", (string data) => {

        });
    }

    private void Add_Refresh() {
        ServerHandler.socket.On("refresh", (string data) => {
            // TODO Move 코루틴 호출
            // TODO timer, minimap, score 등 UI 갱신
        });
    }

    private void Add_Dead() {
        ServerHandler.socket.On("dead", (string data) => {
            // TODO 죽어서 창 띄우기
        });
    }

    private void Add_ChangeCat() {
        ServerHandler.socket.On("change_cat", (string data) => {
            // TODO MyClientData 갱신, CameraPivot을 MyClient.myObject의 위치로 이동
        });
    }

    private void Add_Ban() {
        ServerHandler.socket.On("ban", (string data) => {
            // TODO 해당 유저 파괴하기 (본인 클라이언트의 유저라면 시작화면으로)
        });
    }

    private void Add_GameResult() {
        ServerHandler.socket.On("game_result", (string data) => {
            // TODO GameResult 창 띄우기
        });
    }

}