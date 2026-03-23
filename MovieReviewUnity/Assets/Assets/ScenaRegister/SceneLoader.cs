using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void GoToLogin()
    {
        SceneManager.LoadScene("LoginScene");
    }

    public void GoToRegister()
    {
        SceneManager.LoadScene("RegisterScene");
    }
}