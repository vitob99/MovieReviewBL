using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Logout : MonoBehaviour
{
    [SerializeField] private Button button_logout;
    void Start()
    {
        button_logout.onClick.AddListener(LogOut);
    }

    void LogOut()
    {
        SceneManager.LoadScene(1);
    }
    
}
