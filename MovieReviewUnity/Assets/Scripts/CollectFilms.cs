using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class CollectFilms : MonoBehaviour
{
    private const string FILM_URL = "http://127.0.0.1:5000/film";
    void Start()
    {
        
    }

    // void CollectFilms()
    // {
    //     using (UnityWebRequest request = new UnityWebRequest(FILM_URL, "GET"))
    //         {
    //             request.downloadHandler = new DownloadHandlerBuffer();
    //             request.SetRequestHeader("Content-Type", "application/json");
    //             yield return request.SendWebRequest();

    //             if (request.result == UnityWebRequest.Result.Success)
    //             {
    //                 string jsonResponse = request.downloadHandler.text;
    //                 jsonResponse.ToList();



                    
    //             }
    //             else
    //             {
                    
    //             }
    //         }
    // }
}

   

