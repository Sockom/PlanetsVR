using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ReticleBehavior : MonoBehaviour
{
    [SerializeField] private FunctionManager _functionManager;
    [SerializeField] private TextMeshProUGUI text;
    private GameObject _visuals;

    //get thefirst child game oject as it has all the visual components
    private void Start() => _visuals = transform.GetChild(0).gameObject;
    void Update()
    {
        //get the current plane from oyr AR functions manager
        var plane = _functionManager.GetCurrentPlane();

        //set the child game object (which contains the visual components of our reticle)
        //to activate if the AR functions manager can find a plane
        _visuals.SetActive(plane != null);

        //get the pose from the center screen
        var pose = _functionManager.GetPoseFromScreenCenterOnPlane();

        //if a pose exists  set our rotation and position to its position
        if (!pose.HasValue) return;
        transform.position = pose.Value.position;
        transform.rotation = pose.Value.rotation;

        
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));

        Ray ray = new Ray(Camera.current.transform.position, Camera.current.transform.forward);
        
        RaycastHit[] hits;
        hits = Physics.RaycastAll(ray);
        
        foreach (RaycastHit hit in hits)
        {
            if (hit.transform.gameObject.CompareTag("planet"))
                text.text = hit.transform.gameObject.GetComponent<UnityEngine.UI.Text>().text;
            
        }
    
    }



}
