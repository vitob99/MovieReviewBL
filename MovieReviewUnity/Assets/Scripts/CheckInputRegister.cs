using System;
using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CheckInputRegister : MonoBehaviour
{
    [SerializeField] private TMP_InputField input_username;
    [SerializeField] private TMP_InputField input_password;
    [SerializeField] private TMP_InputField input_email;
    [SerializeField] private Button button_registrati;
    [SerializeField] private TextMeshProUGUI text_error;

    private const string REGISTER_URL = "http://127.0.0.1:5000/user/register";

    void Start()
    {
        button_registrati.onClick.AddListener(() => CheckDati());
        input_username.onSelect.AddListener((select_nome) => input_username.image.color = new Color32(255,255,255,255));
        input_password.onSelect.AddListener((select_email) => input_password.image.color = new Color32(255,255,255,255));
        input_email.onSelect.AddListener((select_email) => input_email.image.color = new Color32(255,255,255,255));
    }

    
    void CheckDati(){
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
        if (input_email.text == "")
        {
            error = true;
            input_email.image.color = new Color32(178, 108, 108, 255);            
        }


        if (error)
        {
            text_error.color = Color.red;
            text_error.text = "Errore: riempi tutti i campi e riprova!";
        }
        else
        {
            text_error.text = "";


            //GESTIONE RICHIESTA DI REGISTRAZIONE
            User registration_data = new User { Username = input_username.text, Email = input_email.text, Password = input_password.text};
            StartCoroutine(SendRegisterRequest(REGISTER_URL, JsonUtility.ToJson(registration_data)));
        }
    }

    IEnumerator SendRegisterRequest(string url, string json)
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
                //utente registrato
                text_error.color = Color.green;
                text_error.text = "Ti sei registrato con successo!";
                yield return new WaitForSeconds(0.5f);
                


                //SceneManager.LoadScene(3); CARICO LA SCENA PRINCIPALE DOPO ESSERMI REGISTRATO !!!!!!



            }
            else if(request.result == UnityWebRequest.Result.ConnectionError)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                text_error.color = Color.red;
                text_error.text = "Errore: username o email già utilizzati!";
            }
        }
    }


}

class User
{
    public string Username;
    public string Email;
    public string Password;
}
