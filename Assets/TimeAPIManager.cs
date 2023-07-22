using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class TimeAPIManager
{
    public IEnumerator GetTimeFromAPI(string apiURL, Action<int,int,int> callback)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(apiURL))
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

            int hours = currentTime.Hour;
            int minutes = currentTime.Minute;
            int seconds = currentTime.Second;

            callback?.Invoke(hours, minutes, seconds);
        }
    }
}
