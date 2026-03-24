using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FilmSlider : MonoBehaviour
{
    [SerializeField] private Image poster;
    [SerializeField] private TextMeshProUGUI titolo;
    [SerializeField] private TextMeshProUGUI recensione;

    [SerializeField] private Film[] films;

    private int currentFilm = 0;

    void Start()
    {
        UpdateFilm();
    }

    public void NextFilm()
    {
        currentFilm++;

        if (currentFilm >= films.Length)
            currentFilm = 0;

        UpdateFilm();
    }

    public void PreviousFilm()
    {
        currentFilm--;

        if (currentFilm < 0)
            currentFilm = films.Length - 1;

        UpdateFilm();
    }

    void UpdateFilm()
    {
        poster.sprite = films[currentFilm].poster;
        titolo.text = films[currentFilm].titolo;
        recensione.text = films[currentFilm].recensione;
    }
}