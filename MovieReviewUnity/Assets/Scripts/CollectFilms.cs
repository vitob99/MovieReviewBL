using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CollectFilms : MonoBehaviour
{
    private static List<Film> FilmList = new List<Film>();
    private static int index_list_film  = 0;
    private int id_film_current;

    [SerializeField] private TextMeshProUGUI text_title;
    [SerializeField] private TextMeshProUGUI text_genre;
    [SerializeField] private TextMeshProUGUI text_year;
    [SerializeField] private TextMeshProUGUI text_director;
    [SerializeField] private RawImage film_poster;
    [SerializeField] private Image star1;
    [SerializeField] private Image star2;
    [SerializeField] private Image star3;
    [SerializeField] private Image star4;
    [SerializeField] private Image star5;
    
    [SerializeField] private Button button_left;
    [SerializeField] private Button button_right;

    [SerializeField] private GameObject stars;
    [SerializeField] private TMP_InputField short_review_input;
    [SerializeField] private TextMeshProUGUI text_error_vote;
    [SerializeField] private TextMeshProUGUI text_success_vote;
    [SerializeField] private Button button_send_vote;

    private const string FILM_URL = "http://127.0.0.1:5000/film";
    
    
    void Start()
    {
        StartCoroutine(Collect());

        button_left.onClick.AddListener(() => ChangeFilm(-1));
        button_right.onClick.AddListener(() => ChangeFilm(1));
    }

    private void ChangeFilm(int direction)
    {
        int movement_index = index_list_film + direction;

        if (movement_index >= 0 && movement_index < FilmList.Count)
        {   
            
            
            text_error_vote.text = "";
            text_success_vote.gameObject.SetActive(false);
            button_send_vote.gameObject.SetActive(true);
            DisableStars(stars);


            index_list_film = movement_index;


            UpdateFilmInfo(index_list_film);
        }
    }
    public void DisableStars(GameObject stars)
    {
        foreach (Transform s in stars.transform)
        {
            Image star = s.GetComponent<Image>();
            star.color = Color.gray;
        }
    }

    public IEnumerator Collect()
    {
        using (UnityWebRequest request = new UnityWebRequest(FILM_URL, "GET"))
        {
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                string jsonResponse = request.downloadHandler.text;
                jsonResponse = "{\"films\":" + jsonResponse + "}";
                FilmListWrapper data = JsonUtility.FromJson<FilmListWrapper>(jsonResponse);
                FilmList = data.films;

                
                UpdateFilmInfo(index_list_film);

            }
            else
            {
                Debug.LogError("Impossibile raggiungere il server!");
            }
        }            
    } 

    public void UpdateFilmInfo(int index)
    {
        text_title.text = FilmList[index].title; 
        text_genre.text = FilmList[index].genre; 
        text_year.text = FilmList[index].year.ToString(); 
        text_director.text = FilmList[index].producer; 

        id_film_current = FilmList[index].filmId;

        StartCoroutine(DownloadAndUpdatePoster());
        StartCoroutine(AverageRating(id_film_current));
    }

    IEnumerator DownloadAndUpdatePoster()
    {
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(FilmList[index_list_film].poster_link))
        {
            yield return uwr.SendWebRequest();

            if (uwr.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Impossibile scaricare l'immagine!");
            }
            else
            {
                film_poster.texture = DownloadHandlerTexture.GetContent(uwr);
            }
        }
    }

    IEnumerator AverageRating(int id_film_current)
    {
        string url = $"http://127.0.0.1:5000/film/average/{id_film_current}";
        
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
            
                string resultText = request.downloadHandler.text;
                
                if (float.TryParse(resultText, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out float average))
                {
                        switch ((int)average)
                        {
                            case 1:
                                star1.color = Color.yellow;
                                star2.color = Color.gray;
                                star3.color = Color.gray;
                                star4.color = Color.gray;
                                star5.color = Color.gray;
                                break;
                            case 2:
                                star1.color = Color.yellow;
                                star2.color = Color.yellow;
                                star3.color = Color.gray;
                                star4.color = Color.gray;
                                star5.color = Color.gray;
                                break;
                            case 3:
                                star1.color = Color.yellow;
                                star2.color = Color.yellow;
                                star3.color = Color.yellow;
                                star4.color = Color.gray;
                                star5.color = Color.gray;
                                break;
                            case 4:
                                star1.color = Color.yellow;
                                star2.color = Color.yellow;
                                star3.color = Color.yellow;
                                star4.color = Color.yellow;
                                star5.color = Color.gray;
                                break;
                            case 5:
                                star1.color = Color.yellow;
                                star2.color = Color.yellow;
                                star3.color = Color.yellow;
                                star4.color = Color.yellow;
                                star5.color = Color.yellow;
                                break;
                        }
                }
            }
            else
            {
                Debug.Log("ERRORE");
            }
        }
    }

    public int getCurrentFilmId()
    {
        return id_film_current;
    }
}
[System.Serializable]
public class Film
{
    public int filmId;
    public string title;
    public int year;
    public string genre;
    public string producer;
    public string poster_link;
}

[System.Serializable]
public class FilmListWrapper
{
    public List<Film> films; 
}
   

