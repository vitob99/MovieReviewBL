using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Networking;

public class BackToLogin : MonoBehaviour
{
    [SerializeField] private Button button_back;
    private const string URL = "http://localhost:5000";

    void Start()
    {
        button_back.onClick.AddListener(() => StartCoroutine(LoadSceneLogin()));
    }

    
    IEnumerator LoadSceneLogin()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(URL))
        {
            request.timeout = 2; 
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ProtocolError)
            {
                SceneManager.LoadScene(1);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
