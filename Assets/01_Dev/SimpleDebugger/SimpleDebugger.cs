/* PLACE THIS SCRIPT ON TEXT(TMP) OBJECT */

using UnityEngine;
using TMPro;

public class SimpleDebugger : MonoBehaviour
{
    public GameObject[] objects;
    void Update()
    {
        string loggingString = "";

        loggingString += this.transform.position + "\n";
        loggingString += this.transform.name + "\n";
        loggingString += this.transform.position + "\n";
        loggingString += this.transform.position + "\n";
        this.GetComponent<TMP_Text>().text = loggingString;
    }
}
