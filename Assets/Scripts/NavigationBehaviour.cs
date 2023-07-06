using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class NavigationBehaviour : MonoBehaviour
{
    private ARSessionOrigin arSessionOrigin;

    public GeoCoordinatesToUnitySpace GeoCoordinatesToUnitySpace;
    private Vector3 targetPosition = GeoCoordinatesToUnitySpace.ConvertGeoCoordinatesToUnity((float)28.551026247183668, (float)77.2689852774038);

    


    private void Start()
    {
        arSessionOrigin = FindObjectOfType<ARSessionOrigin>();
        CameraPositionChanged(); 
    }

    private void CameraPositionChanged()
    {
       
            Transform cameraTransform = arSessionOrigin.camera.transform.parent;
            cameraTransform.position = targetPosition;
       
    }
}
