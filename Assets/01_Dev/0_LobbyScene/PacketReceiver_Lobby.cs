using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.SceneManagement;

public class PacketReceiver_Lobby : MonoBehaviour {

    LobbySceneManager lobbySceneManager;

    private void Start() {

        lobbySceneManager = this.GetComponent<LobbySceneManager>();

    }

    // Listeners

    JObject jObject;

    public void Add_MatchStatus() {

        ServerData.socket.On("match_status", (data) => { // count, maxCount

            jObject = JObject.Parse(data);

            int count = jObject["count"].ToObject<int>();
            int maxCount = jObject["maxCount"].ToObject<int>();
            
            lobbySceneManager.setUserCount(count, maxCount);
            
            if(count == maxCount) {
                SceneManager.LoadScene(1);
            }
        });

    }

}