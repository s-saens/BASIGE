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
            Debug.Log(idJSON.ToString());
            
            ServerData.socket.EmitJson("init", idJSON.ToString(Formatting.None));
            SceneManager.LoadScene(1);

        }
    }

    public void cancel()
    {
        
        JObject idJSON = new JObject();

        idJSON.Add("nickname", ServerData.gameId);
        ServerData.socket.EmitJson("leave", idJSON.ToString());

        SceneManager.LoadScene(0);
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