using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using UnityEngine.XR.ARSubsystems;

public class TapToPlaceManager : MonoBehaviour
{
    public GameObject objectToPlace;
    public GameObject placementIndicator;
    public ARRaycastManager ArOrigin;
    public UnityEvent onObjectPlaced;
    private Pose placementPose;
    private bool placementPoseIsValid = false;
    GameObject target;


    void Start()
    {
        //objectToPlace.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlacementPose();
        UpdatePlacementIndicator();


    }

  


    public void PlaceObject()
    {
        if (placementIndicator.activeSelf)
        {   
            //if (target==null)
            //{
                target = Instantiate(objectToPlace, placementPose.position, placementPose.rotation);
                onObjectPlaced.Invoke();
                //placementIndicator.transform.GetChild(0).gameObject.SetActive(false);
            //}
        }
    }
    public void Restart()
    {
        Destroy(target);
        placementIndicator.transform.GetChild(0).gameObject.SetActive(true);
    }



    private void UpdatePlacementIndicator()
    {
        if (placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
           
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }

    private void UpdatePlacementPose()
    {
        var ScreenCentre = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));

       

        var hits = new List<ARRaycastHit>();
        ArOrigin.Raycast(ScreenCentre, hits, TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            placementPose = hits[0].pose;

            var CameraForward = Camera.current.transform.forward;
            var CameraBraring = new Vector3(CameraForward.x, 0f, CameraForward.z).normalized;
            placementPose.rotation = Quaternion.LookRotation(CameraBraring);

        }
    }


}
