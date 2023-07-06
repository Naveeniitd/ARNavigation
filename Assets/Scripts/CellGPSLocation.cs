using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class CellGPSLocation : MonoBehaviour
{
    public Text _currentLatitude;
    public Text _currentLongitude;
    public void Getlocation()
    {
        // Check if location permission is granted
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            // Request location permission
            Permission.RequestUserPermission(Permission.FineLocation);
        }

        // Start fetching location updates
        StartCoroutine(UpdateLocation());
    }

    IEnumerator UpdateLocation()
    {
        // First, check if user has granted permission
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            yield break;
        }

        // Wait until the location service is enabled
        LocationService locationService = Input.location;
        locationService.Start();

        while (!locationService.isEnabledByUser)
        {
            yield return null;
        }

        // Wait until the location service initializes
        int maxWaitTime = 20;
        while (locationService.status == LocationServiceStatus.Initializing && maxWaitTime > 0)
        {
            yield return new WaitForSeconds(1);
            maxWaitTime--;
        }

        // Check if the location service is able to provide location updates
        if (locationService.status == LocationServiceStatus.Failed)
        {
            Debug.LogError("Failed to get location updates");
            yield break;
        }

        // Fetch the current location
        LocationInfo locationInfo = locationService.lastData;
        float latitude = locationInfo.latitude;
        float longitude = locationInfo.longitude;
        Debug.Log(latitude + " " + longitude);
        // Do something with the latitude and longitude values
        _currentLatitude.text = latitude.ToString();
        _currentLongitude.text = longitude.ToString();


        // Stop the location service
        locationService.Stop();
    }
}