using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FilmManager : MonoBehaviour
{
    [SerializeField] private Image posterGrande;
    [SerializeField] private TextMeshProUGUI titolo;
    [SerializeField] private TextMeshProUGUI recensione;

    [SerializeField] private Sprite[] posters;
    [SerializeField] private string[] titoli;
    [SerializeField] private string[] recensioni;

    public void SelectFilm(int index)
    {
        posterGrande.sprite = posters[index];
        titolo.text = titoli[index];
        recensione.text = recensioni[index];
    }
}