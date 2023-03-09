using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleMission : MonoBehaviour {
    
    public Satellite target;
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

    public bool checkComplete() {
        if (target.altitude > minAlt && target.altitude < maxAlt) return true;
        else return false;
    }

    public void toggleHighlight() {

    }
}
