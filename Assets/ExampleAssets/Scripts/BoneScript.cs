using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class BoneScript : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private GameObject gameObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount <= 0) return;
        var touch = Input.GetTouch(0);
        if (touch.phase != TouchPhase.Began) return;
        Ray ray = camera.ScreenPointToRay(touch.position);
        RaycastHit hit;

        if(Physics.Raycast(ray , out hit))
        {
            if(hit.transform.CompareTag("leg"))
            {
                Instantiate(gameObject, hit.transform.position, hit.transform.rotation);
            }
        }

    }
}
