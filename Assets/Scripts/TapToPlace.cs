using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
public class TapToPlace : MonoBehaviour
{
    public GameObject prefab;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private ARRaycastManager raycastManager;
    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }
    void Update()
    {
        // detect a touch on the screen
        if (Input.touchCount > 0)
        {
            // save the position of the touch on the screen
            Vector2 touchPosition = Input.GetTouch(0).position;
            if (raycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
            {
                var hitPose = hits[0].pose;
                GameObject spawnedPrefab = Instantiate(prefab, hitPose.position, prefab.transform.rotation);
            }
        }
    }
}