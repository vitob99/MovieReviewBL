using UnityEngine;
using TMPro;

public class RegisterManager : MonoBehaviour
{
    public TMP_InputField username;
    public TMP_InputField email;
    public TMP_InputField password;

    public void Register()
    {
        string user = username.text;
        string mail = email.text;
        string pass = password.text;

        if(user == "" || mail == "" || pass == "")
        {
            Debug.Log("Compila tutti i campi");
            return;
        }

        Debug.Log("Utente registrato: " + user);
    }
}