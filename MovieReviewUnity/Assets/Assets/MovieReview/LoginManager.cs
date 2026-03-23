using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

[System.Serializable]
public class LoginRequest
{
    public string username;
    public string password;
}

[System.Serializable]
public class LoginResponse
{
    public string message;
    public string token;
    public string username;
}

public class LoginManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField usernameInput;
    [SerializeField] private TMP_InputField passwordInput;
    [SerializeField] private TMP_Text feedbackText;

    [SerializeField] private string serverUrl = "http://localhost:5000/api/auth/login";

    public void OnLoginClicked()
    {
        // Validazione base
        if (string.IsNullOrWhiteSpace(usernameInput.text) ||
            string.IsNullOrWhiteSpace(passwordInput.text))
        {
            feedbackText.text = "Inserisci username e password";
            return;
        }

        StartCoroutine(Login());
    }

    private IEnumerator Login()
    {
        feedbackText.text = "Accesso in corso...";

        LoginRequest req = new LoginRequest
        {
            username = usernameInput.text,
            password = passwordInput.text
        };

        string json = JsonUtility.ToJson(req);

        UnityWebRequest request = new UnityWebRequest(serverUrl, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);

        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            LoginResponse res = JsonUtility.FromJson<LoginResponse>(request.downloadHandler.text);

            feedbackText.text = "Login effettuato!";
            Debug.Log("Benvenuto: " + res.username);

            // Salva token
            PlayerPrefs.SetString("token", res.token);

            // TODO: cambia scena
            // SceneManager.LoadScene("Home");
        }
        else
        {
            feedbackText.text = "Errore: credenziali non valide o server offline";
            Debug.LogError(request.error);
        }
    }
}