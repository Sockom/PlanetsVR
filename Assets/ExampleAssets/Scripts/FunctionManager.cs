using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class FunctionManager : MonoBehaviour
{
    [SerializeField] private ARRaycastManager _raycastManager;
    [SerializeField] private ARPlaneManager _planeManager;
    

   

public List<ARRaycastHit> GetAllARRaycastHitsFromScreenCenterOnPlane()
    {
        //get the center of the screen
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f,0.5f));

        //initialize a new list of ARRaycastHits
        var hits = new List<ARRaycastHit>();
        //Cast the rays
        
        _raycastManager.Raycast(screenCenter, hits, TrackableType.Planes);
        return hits;
    }

    public ARPlane GetCurrentPlane() {
        //Get the Raycast hits from center screen on planes
        var hits = GetAllARRaycastHitsFromScreenCenterOnPlane();

        //check the hit count, if no hits exist return null
        if (hits.Count <= 0) return null;

        //get the firstthat was hit and retrieve it from the plane manager using its id
        var hit = hits[0];
        return _planeManager.GetPlane(hit.trackableId);
    }


    public Pose? GetPoseFromScreenCenterOnPlane() {
        //Get the Raycast hits from center screen on planes
        var hits = GetAllARRaycastHitsFromScreenCenterOnPlane();

        //check the hit count, if no hits exist return null
        if(hits.Count <= 0) return null;

        //get the first hit and return its pose

        return hits[0].pose;    
    }
}
