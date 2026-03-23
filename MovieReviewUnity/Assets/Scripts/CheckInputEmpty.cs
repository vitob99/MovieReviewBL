using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheckInputEmpty : MonoBehaviour
{
    [SerializeField] private TMP_InputField input_username;
    [SerializeField] private TMP_InputField input_password;
    [SerializeField] private Button button_login;
    [SerializeField] private TextMeshProUGUI text_error;

    void Start()
    {
        button_login.onClick.AddListener(CheckDati);
        input_username.onSelect.AddListener((select_nome) => input_username.image.color = new Color32(255,255,255,255));
        input_password.onSelect.AddListener((select_email) => input_password.image.color = new Color32(255,255,255,255));
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


        if (error)
        {
            text_error.color = Color.red;
            text_error.text = "Errore: riempi tutti i campi e riprova!";
        }
        else
        {
            text_error.text = "";
        }


    }
}
