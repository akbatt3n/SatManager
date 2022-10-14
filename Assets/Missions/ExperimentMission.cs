using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperimentMission : MonoBehaviour {
    
    public float minAlt = 0;
    public float maxAlt = 0;

    public bool checkComplete(Satellite satellite) {
        if (satellite.altitude > minAlt && satellite.altitude < maxAlt) {
            return true;
        }
        else {
            return false;
        }
    }
}
