using System;
using System.Collections;
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

    private const string REGISTER_URL = "http://127.0.0.1/user/register";

    void Start()
    {
        button_registrati.onClick.AddListener(() => StartCoroutine(CheckDati()));
        input_username.onSelect.AddListener((select_nome) => input_username.image.color = new Color32(255,255,255,255));
        input_password.onSelect.AddListener((select_email) => input_password.image.color = new Color32(255,255,255,255));
        input_email.onSelect.AddListener((select_email) => input_email.image.color = new Color32(255,255,255,255));
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

            //DOPO AVER CONTROLLATO SE SONO VUOTI I CAMPI CONTROLLO SE IL SERVER E' UP PRIMA DI PROCEDERE
            using (UnityWebRequest request = UnityWebRequest.Get(REGISTER_URL))
            {
                request.timeout = 1; 
                yield return request.SendWebRequest();
                if (request.result == UnityWebRequest.Result.ProtocolError)
                {
                    
                    //GESTIONE RICHIESTA DI REGISTRAZIONE

                }
                else
                {
                    SceneManager.LoadScene(0);
                }
            }
        }


    }


}
