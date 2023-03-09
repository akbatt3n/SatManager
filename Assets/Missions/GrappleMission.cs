using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleMission : MonoBehaviour {
    
    public Satellite target;
    public GameObject targetObj;
    public float minAlt;
    public float maxAlt;

    int sf;

    // reward in thousands of dollars. needs to be balanced
    public int minReward = 10;
    public int maxReward = 200;
    public int reward;

    public Material pointMaterial;
    public Material highlightedPointMaterial;

    public GameObject listEntry;

    public bool selected = false;

    public void Start() {
        // create target satellite
        // link to mission
    }

    public bool checkComplete() {
        if (target.altitude > minAlt && target.altitude < maxAlt) return true;
        else return false;
    }

    public void toggleHighlight() {
        if (selected) {
            // show target sat orbit/position
            // show orbital parameters in seperate window
        }
        else {
            // hide target sat
            // hide orbital parameter window
        }
    }
}
