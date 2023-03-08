using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class commPayload : MonoBehaviour {

    // if set to true, draw debugging lines
    public bool debugMode = false;

    // make sure this gets set when the satellite is created
    public GameObject commMissions;

    // ms is the vector from the mission location to the satellite
    Vector3 ms1;
    Vector3 ms2;
    
    // maximum angle away from Nadir the sensor can see (degrees)
    public float sensorMaxAngle;
    public float FOVRadius;
    public DecalProjector footprint;

    // the minimum angle the mission location supports (degrees above the horizon)
    // might let the missions decide this
    public float minElevation = 5;

    // cool-down for completing missions - only complete if timer is below 0
    // needs to be balanced
    public int cooldown = 200;
    public int maxCooldown = 400;

    RaycastHit hit1;
    RaycastHit hit2;
    float halfAngle;
    float sf;

    void Start() {
        footprint = GetComponent<DecalProjector>();
        sf = Universe.Instance.scaleFactor;
    }

    void Update() {

        if (Universe.Instance.timeScale == 0) {
            return;
        }

        // display field of view
        if (footprint.enabled) {

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
        if (cooldown <= 0) {
            foreach (Transform mission in commMissions.transform) {
                ms1 = transform.position - mission.GetChild(0).position;
                ms2 = transform.position - mission.GetChild(1).position;

                if (Vector3.Angle(mission.GetChild(0).position, ms1) < (90 - minElevation) && 
                    Vector3.Angle(mission.GetChild(1).position, ms2) < (90 - minElevation)) {
                    if (Vector3.Angle(-transform.position, -ms1) < sensorMaxAngle &&
                        Vector3.Angle(-transform.position, -ms2) < sensorMaxAngle) {
                        // mark mission complete
                        mission.GetComponent<CommMission>().complete();
                        cooldown = maxCooldown;
                        break;
                    }
                }
            }
        }
        else {
            cooldown -= Universe.Instance.timeScale;
        }
        
    }

    public void showFootprint() {
        footprint.enabled = true;
    }

    public void hideFootprint() {
        footprint.enabled = false;
    }
}
