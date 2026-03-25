using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class VoteManager : MonoBehaviour
{
    [SerializeField] private Image[] stars;
    [SerializeField] private Color activeColor = Color.yellow;
    [SerializeField] private Color inactiveColor = Color.gray;
    [SerializeField] private Button button_send_vote;
    [SerializeField] private TextMeshProUGUI text_error;
    [SerializeField] private TextMeshProUGUI text_success;
    [SerializeField] private TMP_InputField input_shortreview;

    [SerializeField] private GameObject film_logic;

    private static int vote = 0;

    public void Start()
    {     
        text_success.gameObject.SetActive(false);
        foreach (var item in stars)
        {
            item.color = inactiveColor;
        }
        button_send_vote.onClick.AddListener(SendVote);
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

        vote = value;
    }

    public void SendVote()
    {
        if(vote == 0)
        {
            text_error.text = "Assegna un voto prima di inviare!";
        }
        else
        {
            int user_id_review = LoggedUserSingleton.Instance.getLoggedUser().userId;
     

            int user_id_film = film_logic.GetComponent<CollectFilms>().getCurrentFilmId();
         

            SentReview review = new SentReview {UserId = user_id_review, FilmId = user_id_film, Rating = vote, ShortReview = input_shortreview.text};
            string POST_REVIEW_URL = $"http://127.0.0.1:5000/film/post_review";
            StartCoroutine(SendReview(POST_REVIEW_URL, JsonUtility.ToJson(review)));
        }
    }

    IEnumerator SendReview(string url, string json)
    {
        using (UnityWebRequest request = new UnityWebRequest(url, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                text_error.text = "";
                button_send_vote.gameObject.SetActive(false);
                text_success.gameObject.SetActive(true); 
            }
            else
            {
                Debug.Log("ERRORE");
            }
        }
    }
}

[System.Serializable]
public class SentReview
{
   public int UserId;
   public int FilmId;
   public int Rating;
   public string ShortReview;
}