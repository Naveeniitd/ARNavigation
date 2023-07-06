using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class RouteAPIManager : MonoBehaviour
{
    public InputField _dest_longitude;
    public InputField _dest_latitude;
    private string apiURL = "https://apis.mappls.com/advancedmaps/v1";
    private string apiKey = "17aa19c807d0281f350dcf93b0a3d1d4";
    public Main RouteData;
    public List<Vector2> decodedPoints;
    public string endLat;
    public string endLon;
    public void GetDirection()
    {
        string startLat = "28.550816286228194";
        string startLon = "77.26878716302788";
        string endLat = _dest_latitude.text;
        string endLon = _dest_longitude.text;
        
        string requestURL = $"{apiURL}/{apiKey}/route_adv/walking/{startLon},{startLat};{endLon},{endLat}?steps=true";
        Debug.Log(requestURL);
        StartCoroutine(SendRequest(requestURL));
    }

    private IEnumerator SendRequest(string url)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {   
            webRequest.SetRequestHeader("accept", "application/json");
            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("API request failed!");
                Debug.LogError(webRequest.error);
            }
            else
            {
                Debug.Log("API request succeeded!");
                string jsonData = webRequest.downloadHandler.text;
                Debug.Log(jsonData);
                //parsing of json data
                RouteData = JsonUtility.FromJson<Main>(jsonData);
                string encodedGeo = RouteData.routes[0].geometry;
                decodedPoints = Decode(encodedGeo);
                Debug.Log(decodedPoints.Count);
                for (int i = 0; i < decodedPoints.Count; i++)
                {
                    Vector2 point = decodedPoints[i];
                    string Latlong = $"Vector2: ({point.x:F5}, {point.y:F5})";
                    Debug.Log(Latlong);
                    
                }
            }
        }
    }
    //Decoding the geometery
    private  List<Vector2> Decode(string encoded)
    {
        List<Vector2> points = new List<Vector2>();
        int index = 0;
        int len = encoded.Length;
        int lat = 0;
        int lng = 0;

        while (index < len)
        {
            int b;
            int shift = 0;
            int result = 0;

            do
            {
                b = encoded[index++] - 63;
                result |= (b & 0x1f) << shift;
                shift += 5;
            } while (b >= 0x20);

            int dlat = ((result & 1) != 0 ? ~(result >> 1) : (result >> 1));
            lat += dlat;

            shift = 0;
            result = 0;

            do
            {
                b = encoded[index++] - 63;
                result |= (b & 0x1f) << shift;
                shift += 5;
            } while (b >= 0x20);

            int dlng = ((result & 1) != 0 ? ~(result >> 1) : (result >> 1));
            lng += dlng;

            points.Add(new Vector2(lat / 1E5f, lng / 1E5f));
            
        }

        return points;
    }
}
