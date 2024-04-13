using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class MarsWeather : MonoBehaviour
{
    public string apiUrl = "https://api.nasa.gov/insight_weather/?api_key=DEMO_KEY&feedtype=json&ver=1.0";

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FetchData());
    }
    [System.Serializable]
    public class MarsWeatherData
    {
        public List<string> sol_keys;
        public Dictionary<string, WeatherData> sol_data;
    }
    [System.Serializable]
    public class WeatherData
    {
        public AtmosphericData AT;
        public AtmosphericData PRE;
        public AtmosphericData HWS;
        public WindDirectionData WD;
    }

    [System.Serializable]
    public class AtmosphericData
    {
        public float av;
    }

    [System.Serializable]
    public class WindDirectionData
    {
        public WindCompassPoint most_common;
    }

    [System.Serializable]
    public class WindCompassPoint
    {
        public string compass_point;
    }

    IEnumerator FetchData()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(apiUrl))
        {
            yield return webRequest.SendWebRequest();

            // Check for errors
            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("Error: " + webRequest.error);
            }
            else
            {
                // Parse JSON data
                string jsonData = webRequest.downloadHandler.text;
                Debug.Log("Received data: " + jsonData);
                MarsWeatherData JSON = JsonUtility.FromJson<MarsWeatherData>(jsonData);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
