using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeoCoordinatesToUnitySpace : MonoBehaviour 
{
    public Vector3 ConvertGeoCoordinatesToUnity(float latitude, float longitude)
    {

        float latitudeScale = 1000;
        float longitudeScale = 1000;

        // Map the scaled latitude and longitude to Unity's X and Z coordinates
        float unityX = longitude * longitudeScale;
        float unityZ = latitude * latitudeScale;

        // Determine the Y coordinate in Unity's world space
        float unityY = 0;

        // Return the converted Unity coordinates as a Vector3

        return new Vector3(unityX, unityY, unityZ);
    }

}
