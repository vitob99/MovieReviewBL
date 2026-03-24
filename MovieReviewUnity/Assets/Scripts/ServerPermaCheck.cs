using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;


public class ServerPermaCheck : MonoBehaviour
{
    private const string URL = "http://localhost:5000";


    void Start()
    {
        StartCoroutine(CheckServer());
    }

    IEnumerator CheckServer()
    {
        while (true)
        {
            using (UnityWebRequest request = UnityWebRequest.Get(URL))
            {
                request.timeout = 1; 
                yield return request.SendWebRequest();

                if (request.result == UnityWebRequest.Result.ConnectionError)
                {
                    SceneManager.LoadScene(0);
                    yield break; 
                }
            }
            yield return new WaitForSeconds(2f);
        }
    }
}

