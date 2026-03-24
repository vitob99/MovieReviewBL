using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.Collections;

public class ToRegister : MonoBehaviour
{
    [SerializeField] private Button button_toregister;
    private const string URL = "http://localhost:5000";
    void Start()
    {
        button_toregister.onClick.AddListener(() => StartCoroutine(LoadSceneRegister()));
    }

    IEnumerator LoadSceneRegister()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(URL))
        {
            request.timeout = 2; 
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ProtocolError)
            {
                SceneManager.LoadScene(2);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
