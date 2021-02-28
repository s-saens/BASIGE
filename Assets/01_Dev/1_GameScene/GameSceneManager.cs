using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{

    public void Exit()
    {
        JObject idJSON = new JObject();
        idJSON.Add("nickname", ServerData.gameId);
        ServerData.socket.EmitJson("leave", idJSON.ToString());
        SceneManager.LoadScene(0);
    }

}
