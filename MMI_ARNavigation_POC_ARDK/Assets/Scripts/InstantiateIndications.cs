using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateIndications : MonoBehaviour

{
    // Reference point coordinates (known latitude and longitude)

    public GameObject _indications;
    public RouteAPIManager routeAPIManager;
    public GeoCoordinatesToUnitySpace GeoCoordinatesToUnitySpace;
    /* public CellGPSLocation _cellGPSLocation;
     public float CurrentLatitude = _cellGPSLocation;
     public float CurrentLongitude;*/
    // Instantiate an object at a specific latitude and longitude
    public void InstantiateObjectAtLocation()
    {
        {
            /*// Calculate the position offset from the current position
            float x = (float)(longitude - CurrentLongitude) * Mathf.Cos((float)CurrentLatitude);
            float z = (float)(latitude - CurrentLatitude);*/
            Debug.Log(routeAPIManager.decodedPoints.Count);
            List<Vector2> indication = routeAPIManager.decodedPoints;

            for (int i = 0; i < indication.Count; i++)
            {
                Vector2 vector2 = indication[i];

                Vector3 vector3 = GeoCoordinatesToUnitySpace.ConvertGeoCoordinatesToUnity(vector2.x, vector2.y);

                // Instantiate the object at the calculated position

                Vector3 position = new Vector3(vector3.x, vector3.y, vector3.z);
                Instantiate(_indications, position, Quaternion.identity);
            }


        }
    }
    
    }


