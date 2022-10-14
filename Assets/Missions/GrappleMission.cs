using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleMission : MonoBehaviour {
    
    public Satellite target;
    public float minAlt;
    public float maxAlt;

    public bool checkComplete() {
        if (target.altitude > minAlt && target.altitude < maxAlt) return true;
        else return false;
    }
}
