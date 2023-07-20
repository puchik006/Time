using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class TimeAPIManager : MonoBehaviour
{
    //[SerializeField] private string apiUrl = "http://worldtimeapi.org/api/ip";

    [SerializeField] private string apiUrl = "https://time.is/";

    private void Start()
    {
        StartCoroutine(GetTimeFromAPI());
    }

    private IEnumerator GetTimeFromAPI()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(apiUrl))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error fetching time from API: " + webRequest.error);
                yield break;
            }

            string jsonResponse = webRequest.downloadHandler.text;
            WorldTimeAPIResponse response = JsonUtility.FromJson<WorldTimeAPIResponse>(jsonResponse);
            DateTime currentTime = DateTime.Parse(response.datetime);
            Debug.Log("Current Time: " + currentTime);
        }
    }
}
