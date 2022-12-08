using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class commPayload : MonoBehaviour {

    // make sure this gets set when the satellite is created
    public GameObject commMissions;

    // ms is the vector from the mission location to the satellite
    Vector3 ms1;
    Vector3 ms2;
    
    // maximum angle away from Nadir the sensor can see (degrees)
    public float sensorMaxAngle = 45;

    // the minimum angle the mission location supports (degrees above the horizon)
    // might let the missions decide this
    public float minMissionAngle = 5;

    void Update() {

        foreach (Transform mission in commMissions.transform) {
            ms1 = transform.position - mission.GetChild(0).position;
            ms2 = transform.position - mission.GetChild(1).position;

            if (Vector3.Angle(-mission.GetChild(0).position, ms1) > (90 + minMissionAngle) && 
                Vector3.Angle(-mission.GetChild(1).position, ms2) > (90 + minMissionAngle)) {
                if (Vector3.Angle(-transform.position, -ms1) > sensorMaxAngle &&
                    Vector3.Angle(-transform.position, -ms2) > sensorMaxAngle) {
                    // mark mission complete
                    mission.GetComponent<CommMission>().complete();
                }
            }
        }
        
    }
}
