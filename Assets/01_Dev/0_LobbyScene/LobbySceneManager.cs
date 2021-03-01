using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class LobbySceneManager : MonoBehaviour
{

    public InputField inputName;
    public GameObject EnterTheNameIMG;
    public Text userCount;
    public GameObject canvas_matching;
    public GameObject canvas_main;
    
    // Input Scene to Matching Scene
    
    public void GameStart()
    {
        if(inputName.text == "") 
        {   
            EnterTheNameIMG.gameObject.SetActive(true);
        }
        else
        {
            string nickname = inputName.text;
            inputName.text = "";

            JObject idJSON = new JObject();
            idJSON.Add("nickname", nickname);

            Debug.Log(ServerData.socket.Url.UserInfo);

            ServerData.socket.EmitJson("init", idJSON.ToString(Formatting.None));

            canvas_matching.SetActive(true);
            canvas_main.SetActive(false);

            this.GetComponent<PacketReceiver_Lobby>().Add_MatchStatus();

        }
    }

    public void cancel()
    {
        
        JObject idJSON = new JObject();

        idJSON.Add("nickname", ServerData.gameId);
        ServerData.socket.EmitJson("leave", idJSON.ToString());
        this.GetComponent<ServerInitializer>().Awake(); // ReInitialize server socket

        canvas_main.SetActive(true);
        canvas_matching.SetActive(false);
    }

    public void setUserCount(int count, int maxCount) {

        userCount.text = "";
        userCount.text += count;
        userCount.text += " / ";
        userCount.text += maxCount;

    }

    
    JObject jObject;

    private void Add_MatchStatus() {

        ServerData.socket.On("match_status", (data) => { // count, maxCount

            Debug.Log(data);

            jObject = JObject.Parse(data);

            int count = jObject["count"].ToObject<int>();
            int maxCount = jObject["maxCount"].ToObject<int>();

            this.GetComponent<LobbySceneManager>().setUserCount(count, maxCount);
            
            if(count == maxCount) {
                SceneManager.LoadScene(2);
            }
        });

    }


}