using Newtonsoft.Json.Linq;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections.Generic;

using TMPro;

public class GameSceneManager : MonoBehaviour
{

    public TMP_Text scoreText;
    private int bugScore = 0;
    private int catScore = 0;

    public void Exit()
    {
        JObject idJSON = new JObject();
        idJSON.Add("nickname", ServerData.gameId);
        ServerData.socket.EmitJson("leave", idJSON.ToString());
        SceneManager.LoadScene(0);
    }

    public void UpdateScore() {
        this.scoreText.text = this.bugScore + " :  " + this.catScore;
    }

    private void GetScore() {
        foreach(KeyValuePair<string, User> userPair in ServerData.users) {

            User user = userPair.Value;

            bugScore = 0;
            catScore = 0;

            if(user.type == UserType.BUG) {
                this.bugScore += user.score;
            }
            else { // cat
                this.catScore = user.score;
            }
        }
    }

}
