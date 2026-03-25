using UnityEngine;

public sealed class LoggedUserSingleton : MonoBehaviour
{
    public static LoggedUserSingleton Instance;

    private LoginUser logged_user; 


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void setLoggedUser(LoginUser u)
    {
        logged_user = u;
    }

    public LoginUser getLoggedUser()
    {
        return logged_user;
    }
}