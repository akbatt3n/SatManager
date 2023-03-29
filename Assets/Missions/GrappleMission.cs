using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleMission : MonoBehaviour {
    
    public Satellite target;
    public GameObject targetObj;
    public GameObject targetPrefab;
    public GameObject msysObj;
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
        
        // pick random orbit
        int altitude;
        int inclination;
        int raan;

        switch (Random.Range(0, 2)) {
            case 0:
                altitude = 175 + (int)(450 * Random.Range(0f, 1f));
                inclination = Random.Range(0, 90);
                raan = Random.Range(0, 360);
                break;
            case 1:
            default:
                altitude = 35786;
                switch (Random.Range(0, 2)) {
                    case 0:
                        inclination = Random.Range(0, 3);
                        break;
                    case 1:
                    default:
                        inclination = Random.Range(0, 20);
                        break;
                }
                raan = Random.Range(0, 360);
                break;
        }

        // pick random name, like a COSPAR ID
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYX";
        string name = Random.Range(1995, 2025).ToString() + "-" + Random.Range(1, 125).ToString("000") + chars[Random.Range(0, 26)];
        while(msysObj.GetComponent<MissionSystem>().targetNames.Contains(name)) {
            name = Random.Range(1995, 2025).ToString() + "-" + Random.Range(1, 125).ToString("000") + chars[Random.Range(0, 26)];
        }

        // create target satellite
        targetObj = Universe.Instance.launchSatellite(false,
                                                        name,
                                                        "Target",
                                                        altitude,
                                                        inclination,
                                                        raan,
                                                        0,
                                                        0);

        target = targetObj.GetComponent<Satellite>();
        target.hideOrbit();
    }

    public bool checkComplete() {
        if (target.altitude > minAlt && target.altitude < maxAlt) return true;
        else return false;
    }

    public void toggleHighlight() {
        if (selected && target != null) {
            // show target sat orbit/position
            target.showOrbit();
            // show orbital parameters in seperate window
            msysObj.GetComponent<MissionSystem>().showGrappleTargetParam(this);
        }
        else if (target != null) {
            // hide target sat
            target.hideOrbit();
            // hide orbital parameter window
            msysObj.GetComponent<MissionSystem>().hideGrappleTargetParam();
        }
    }
}
