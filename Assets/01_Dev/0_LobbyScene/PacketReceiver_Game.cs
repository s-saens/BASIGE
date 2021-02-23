using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.SceneManagement;

public class PacketReceiver_Game : MonoBehaviour {


    private void Start() {
        Add_MatchStatus();
    }

    // Listeners

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