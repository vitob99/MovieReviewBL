using System;
using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CheckInputLogin : MonoBehaviour
{
    [SerializeField] private TMP_InputField input_username;
    [SerializeField] private TMP_InputField input_password;
    [SerializeField] private Button button_login;
    [SerializeField] private TextMeshProUGUI text_error;
    private const string LOGIN_URL = "http://127.0.0.1:5000/user/login";

    void Start()
    {
        button_login.onClick.AddListener(() => StartCoroutine(CheckDati()));
        input_username.onSelect.AddListener((select_nome) => input_username.image.color = new Color32(255,255,255,255));
        input_password.onSelect.AddListener((select_email) => input_password.image.color = new Color32(255,255,255,255));
    }

    
    IEnumerator CheckDati(){
        bool error = false;
        if(input_username.text == "")
        {
            error = true;
            input_username.image.color = new Color32(178, 108, 108, 255);
        }

        if(input_password.text == "")
        {
            error = true;
            input_password.image.color = new Color32(178, 108, 108, 255);
        }


        if (error)
        {
            text_error.color = Color.red;
            text_error.text = "Errore: riempi tutti i campi e riprova!";
        }
        else
        {


            //DOPO AVER CONTROLLATO SE SONO VUOTI I CAMPI CONTROLLO SE IL SERVER E' UP PRIMA DI PROCEDERE
            using (UnityWebRequest request = UnityWebRequest.Get(LOGIN_URL))
            {
                request.timeout = 1; 
                yield return request.SendWebRequest();
                if (request.result == UnityWebRequest.Result.ProtocolError)
                {
                    LoginRequest data = new LoginRequest { username = input_username.text, password = input_password.text};
                    StartCoroutine(SendRequest(LOGIN_URL, JsonUtility.ToJson(data))); 
                }
                else
                {
                    SceneManager.LoadScene(0);
                }
            }
        }

        IEnumerator SendRequest(string url, string json)
        {
            using (UnityWebRequest request = new UnityWebRequest(url, "POST"))
            {
                byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
                request.uploadHandler = new UploadHandlerRaw(bodyRaw);
                request.downloadHandler = new DownloadHandlerBuffer();
                request.SetRequestHeader("Content-Type", "application/json");
                yield return request.SendWebRequest();

                if (request.result == UnityWebRequest.Result.Success)
                {
                    // scena principale da loggato
                    text_error.color = Color.green;
                    text_error.text = $"Benvenuto, '{input_username.text}'";
                    yield return new WaitForSeconds(0.5f);

                    //APRI LA SCENA DELL'UTENTE LOGGATO... SceneManager.LoadScene(3);
                }
                else if(request.result == UnityWebRequest.Result.ConnectionError)
                {
                    SceneManager.LoadScene(0);
                }
                else
                {
                    text_error.color = Color.red;
                    text_error.text = "Errore: username o password errati!";
                }
            }
        }

    }
}
