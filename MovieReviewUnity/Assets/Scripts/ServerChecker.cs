using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using TMPro; 
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class ServerChecker : MonoBehaviour
{
    const int MAX_TRIES = 3;
    [SerializeField] private TextMeshProUGUI text_error;
    [SerializeField] private GameObject loading;
    [SerializeField] private RawImage retry_image;

    private string url = "http://127.0.0.1:5000";

    void Start()
    {
        Button button_retry = retry_image.GetComponent<Button>();
        button_retry.onClick.AddListener(Start);


        loading.GetComponent<Animator>().speed = 1;
        retry_image.enabled = false;
        StartCoroutine(BlockingConnectionRoutine());
    }

    IEnumerator BlockingConnectionRoutine()
    {
        bool connected = false;
        int tries = 0;
        do
        {
            text_error.color = Color.white;
            text_error.text = "Connessione al server in corso...";
            yield return new WaitForSeconds(1f); 

            tries++;
            using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
            {
                yield return webRequest.SendWebRequest();

                if (webRequest.result == UnityWebRequest.Result.ProtocolError)
                {
                    text_error.color = Color.green;
                    text_error.text = "Connessione al server riuscita...";
                    yield return new WaitForSeconds(1f);
                    SceneManager.LoadScene(1);
                    connected = true;
                }
                else
                {
                    if(tries < MAX_TRIES)
                    {
                        text_error.color = Color.orange;
                        text_error.text = "Impossibile raggiungere il server, eseguo un nuovo tentativo...";
                        yield return new WaitForSeconds(2f); 
                    }
                }
            }
        }while (!connected && tries < MAX_TRIES);

        if(connected == false)
        {
            loading.GetComponent<Animator>().speed = 0;
            text_error.color = Color.red;
            text_error.text = "Limite tentativi raggiunto, impossibile connettersi al server...";
            retry_image.enabled = true;
        } 
    }
}