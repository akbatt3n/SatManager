using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class imagePayload : MonoBehaviour {
    
    // make sure this gets set when the satellite is created
    public GameObject imageMissions;

    // ms is the vector from the mission location to the satellite
    Vector3 ms;
    
    // maximum angle away from Nadir the sensor can see (degrees)
    public float sensorMaxAngle = 45;
    public float FOVRadius;
    public DecalProjector footprint;

    // the minimum angle the mission location supports (degrees above the horizon)
    // might let the missions decide this
    public float minElevation = 35;

    RaycastHit hit1;
    RaycastHit hit2;
    float halfAngle;
    float sf;

    void Start() {
        footprint = GetComponent<DecalProjector>();
        sf = Universe.Instance.scaleFactor;
    }

    void Update() {

        // display field of view
        if (footprint.enabled && Universe.Instance.timeScale != 0) {

            // If Raycast returns true, the satellite FOV is sensor limited (not horizon limited)
            if (Physics.Raycast(transform.position, Vector3.RotateTowards(transform.forward, transform.right, sensorMaxAngle*Mathf.PI/180, 0f), out hit1, transform.position.magnitude)) {
                Physics.Raycast(transform.position, Vector3.RotateTowards(transform.forward, -transform.right, sensorMaxAngle*Mathf.PI/180, 0f), out hit2, transform.position.magnitude);

                FOVRadius = Vector3.Distance(hit1.point, hit2.point);
            }

            // sensor FOV is larger than Earth, calculate based on horizon limit
            else {
                // based on trig, minus a very small value so the rays don't miss the Earth due to computer rounding errors
                halfAngle = Mathf.Asin(6.371f / transform.position.magnitude) - 0.0001f;

                Physics.Raycast(transform.position, Vector3.RotateTowards(transform.forward, transform.right, halfAngle, 0f), out hit1, transform.position.magnitude);
                Physics.Raycast(transform.position, Vector3.RotateTowards(transform.forward, -transform.right, halfAngle, 0f), out hit2, transform.position.magnitude);
                FOVRadius = Vector3.Distance(hit1.point, hit2.point);

            }
            footprint.size = new Vector3(FOVRadius, FOVRadius, transform.position.magnitude);
            footprint.pivot = new Vector3(0, 0, transform.position.magnitude/2);
        }

        // search for missions to complete
        foreach (Transform mission in imageMissions.transform) {
            ms = transform.position - mission.position;

            if (Vector3.Angle(-mission.position, ms) > (90 + minElevation)) {
                if (Vector3.Angle(-transform.position, -ms) < sensorMaxAngle) {
                    // mark mission complete
                    // mission.GetComponent<mission>().complete();
                }
            }
        }
        
    }

    public void showFootprint() {
        footprint.enabled = true;
    }

    public void hideFootprint() {
        footprint.enabled = false;
    }
}
