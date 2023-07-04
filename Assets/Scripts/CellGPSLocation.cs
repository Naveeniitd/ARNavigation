using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
public class CellGPSLocation : MonoBehaviour
{
    IEnumerator Start()
    {   
        //Ask user to authorize permission for GPS
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
            Permission.RequestUserPermission(Permission.CoarseLocation);
        }
        // Check if location services are enabled
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("Location services are not enabled.");
            yield break;
        }

        // Start location service updates with desired accuracy and distance
        Input.location.Start();

        // Wait until location service initializes
        int maxWaitTime = 10;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWaitTime > 0)
        {
            yield return new WaitForSeconds(1);
            maxWaitTime--;
        }

        // Location service didn't initialize within the allowed time
        if (maxWaitTime <= 0)
        {
            Debug.Log("Timed out while initializing location service.");
            yield break;
        }

        // Location service failed to start
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Failed to start location service.");
            yield break;
        }

        // Retrieve the latitude and longitude coordinates
        float Deivcelatitude = Input.location.lastData.latitude;
        float Devicelongitude = Input.location.lastData.longitude;

       

        
    }
}