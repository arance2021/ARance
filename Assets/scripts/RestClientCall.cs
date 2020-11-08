using System;
 using System.Collections;
 using UnityEngine;
 using UnityEngine.Networking;


public class RestClientCall : MonoBehaviour
{

  // Where to send our request
  const string DEFAULT_URL = "https://jsonplaceholder.typicode.com/todos/1";
  string targetUrl = DEFAULT_URL;

  // Keep track of what we got back
  string recentData = "";


  public void HandleButtonClick()  {
        this.StartCoroutine(this.RequestRoutine(this.targetUrl, this.ResponseCallback));
    }

    private IEnumerator RequestRoutine(string url, Action<string> callback = null)    {
        var request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();
        var data = request.downloadHandler.text;
        if (callback != null)
            callback(data);
    }

    private void ResponseCallback(string data)  {
        Debug.Log(data);
        recentData = data;
    }




}
