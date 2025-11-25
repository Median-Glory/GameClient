using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class APITestScript : MonoBehaviour
{
    private string apiURL = "http://localhost:8085/game";

    void Start()
    {
        StartCoroutine(GetTest(apiURL));
    }

    IEnumerator GetTest(string url)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError ||
                webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error: " + webRequest.error);
            }
            else
            {
                string receivedText = webRequest.downloadHandler.text;

                Debug.Log("result : " + receivedText);
            }
        }
    }

}
