using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class imagePayload : MonoBehaviour {
    
    // make sure this gets set when the satellite is created
    public GameObject imageMissions;

    // ms is the vector from the mission location to the satellite
    Vector3 ms;
    
    // maximum angle away from Nadir the sensor can see (degrees)
    public float sensorMaxAngle = 35;

    // the minimum angle the mission location supports (degrees above the horizon)
    // might let the missions decide this
    public float minMissionAngle = 45;

    void Update() {

        foreach (Transform mission in imageMissions.transform) {
            ms = transform.position - mission.position;

            if (Vector3.Angle(-mission.position, ms) > (90 + minMissionAngle)) {
                if (Vector3.Angle(-transform.position, -ms) < sensorMaxAngle) {
                    // mark mission complete
                    // mission.GetComponent<mission>().complete();
                }
            }
        }
        
    }
}
