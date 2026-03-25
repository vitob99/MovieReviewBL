using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoutManager : MonoBehaviour
{
    public void Logout()
    {
        // Cancella eventuali dati di login
        PlayerPrefs.DeleteAll();

        // Torna alla scena di login
        SceneManager.LoadScene("LoginScene");
    }
}