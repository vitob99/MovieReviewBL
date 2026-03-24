using UnityEngine;
using UnityEngine.UI;

public class VoteManager : MonoBehaviour
{
    [SerializeField] private Image[] stars;
    [SerializeField] private Color activeColor = Color.yellow;
    [SerializeField] private Color inactiveColor = Color.gray;

    public void Start()
    {
        foreach (var item in stars)
        {
            item.color = inactiveColor;
        }
    }
    public void Vote(int value)
    {
        for (int i = 0; i < stars.Length; i++)
        {
            if (i < value)
                stars[i].color = activeColor;
            else
                stars[i].color = inactiveColor;
        }
    }
}