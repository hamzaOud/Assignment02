using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlaneController : MonoBehaviour
{
    ARPlaneManager ARPlanemanager;

    // Start is called before the first frame update
    void Start()
    {
        ARPlanemanager = GetComponent<ARPlaneManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ARPlanemanager.trackables.count >=1)
        {
            ARPlanemanager.enabled = false;
        }

    }
}
