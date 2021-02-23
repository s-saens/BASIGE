/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ServerHandler.socket.On("game_result", (string data) => {
//        string data=socketIOEVENT.DATA.ToString();
//        GAME_RESULT__STC gameResult=JsonUtility.FromJson<GAME_RESULT__STC>(data);
//        SceneManager.LoadScene("Test");
//        GameResult.setText(gameResult.winner, gameResult.catScore,gameResult.bugScore);
// });


public class GameResult : MonoBehaviour
{
    private Text winner;
    private Text result;

    // Start is called before the first frame update
    void Start()
    {
        winner=GameObject.Find("Win/LoseText").GetComponent<Text>();
        result=GameObject.Find("ResultText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void setText(GAME_RESULT__STC winner, GAME_RESULT__STC catScore,GAME_RESULT__STC bugScore){
        
        if(MyClientData.userType.ToString().Equals(winner)){
            this.winner.text="You Win!";
        }
        else{
            this.winner.text="You Lose..";
        }
        this.result.text="Cat : "+catScore+" 점    Bug : "+bugScore+(" 점");
    }
}*/