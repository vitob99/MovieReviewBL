using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
    [SerializeField] private Button button_exit;
    void Start()
    {
        button_exit.onClick.AddListener(() => Application.Quit());
    }
}
