using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.SceneManagement;

public class Event_MainScene : MonoBehaviour {

    Queue<IEnumerator> eventQueue = new Queue<IEnumerator>();

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

            this.GetComponent<MainSceneManager>().setUserCount(count, maxCount);
            if(count == maxCount) {
                SceneManager.LoadScene(2);
            }
        });
    }

}