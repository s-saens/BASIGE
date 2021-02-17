using UnityEngine;
using socket.io;
using System.Threading.Tasks;

public class ServerHandler : MonoBehaviour
{
    
    public static Socket socket;
    private string serverURL = "http://203.254.143.190:3000";

    private void Start() {

        InitializeServerSocket();

    }

    private void InitializeServerSocket() {

        socket = Socket.Connect(serverURL);
        
        // 연결이 된 경우 실행
        socket.On(SystemEvents.connect, () => {
            Debug.Log("Connected successfully");
            socket.Emit("test", "name: 'testA'");

            AddAllListeners();
        });

    }

    private void AddAllListeners() {
        Add_MatchStatus();
        Add_Render();
        Add_SkillResult();
        Add_Refresh();
        Add_Dead();
        Add_ChangeCat();
        Add_Ban();
        Add_GameResult();
    }

    // Packets From Server

    MATCH_STATUS__STC mathc_status_info;
    RENDER__STC render_info;
    SKILL_RESULT__STC skill_result_info;
    REFRESH__STC refresh_info;
    DEAD__STC dead_info;
    CHANGE_CAT__STC change_cat_info;
    BAN__STC ban_info;
    GAME_RESULT__STC game_result_info;

    // Listeners

    private void Add_MatchStatus() {
        socket.On("match_status", (string data) => {
            mathc_status_info = JsonUtility.FromJson<MATCH_STATUS__STC>(data);
            // TODO
        });
    }

    private void Add_Render() {
        socket.On("render", (string data) => {
            render_info = JsonUtility.FromJson<RENDER__STC>(data);

            GameRenderer gameRenderer = this.GetComponent<GameRenderer>();
            gameRenderer.Render();
        });
    }

    // 패킷 없음! //
    private void Add_GameStart() {
        socket.On("game_start", (string data) => {
            // TODO 클라이언트 조작가능하게 변경
        });
    }

    private void Add_SkillResult() {
        socket.On("skill_result", (string data) => {

            skill_result_info = JsonUtility.FromJson<SKILL_RESULT__STC>(data);

            switch(skill_result_info.skillResult) {

                case SkillResult.SUCCESS:
                    // TODO 스킬사용 코루틴 호출
                    break;

                case SkillResult.NO_COOL:
                    // TODO 쿨타임이 아직 안됐다고 띄우기
                    break;
                
            }

        });
    }

    private void Add_Refresh() {
        socket.On("refresh", (string data) => {
            refresh_info = JsonUtility.FromJson<REFRESH__STC>(data);
            // TODO Move 코루틴 호출
            // TODO timer, minimap, score 등 UI 갱신
        });
    }

    private void Add_Dead() {
        socket.On("dead", (string data) => {
            dead_info = JsonUtility.FromJson<DEAD__STC>(data);
            // TODO 죽어서 창 띄우기
        });
    }

    private void Add_ChangeCat() {
        socket.On("change_cat", (string data) => {
            change_cat_info = JsonUtility.FromJson<CHANGE_CAT__STC>(data);
            // TODO MyClientData 갱신, CameraPivot을 MyClient.myObject의 위치로 이동
        });
    }

    private void Add_Ban() {
        socket.On("ban", (string data) => {
            ban_info = JsonUtility.FromJson<BAN__STC>(data);
            // TODO 해당 유저 파괴하기 (본인 클라이언트의 유저라면 시작화면으로)
        });
    }

    private void Add_GameResult() {
        socket.On("game_result", (string data) => {
            game_result_info = JsonUtility.FromJson<GAME_RESULT__STC>(data);
            // TODO GameResult 창 띄우기
        });
    }


    
}