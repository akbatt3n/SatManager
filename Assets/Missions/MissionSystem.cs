using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionSystem : MonoBehaviour {

    public int newMissionTime; // time before a new mission gets added in sec
    public GameObject commMissionPrefab;
    public GameObject imageMissionPrefab;
    public GameObject experimentMissionPrefab;
    public GameObject grappleMissionPrefab;

    void Start() {
        InvokeRepeating("timerUpdate", 10f, 1f);
    }

    void timerUpdate() {
        if (newMissionTime < 0f) {
            addMission();
            newMissionTime = Random.Range(30, 240);
        }

        newMissionTime -= 1;
    }

    public void addMission() {
        float chanceComm = 0.40;
        float chanceImage = 0.20;
        float chanceExp = 0.30;
        float chanceGrapple = 0.10;

        float roll = Random.Range(0f, 1f);

        if (roll < chanceComm) {
            newCommMission();
        }
        else if (roll < chanceComm + chanceImage) {
            newImageMission();
        }
        else if (roll < chanceComm + chanceImage + chanceExp) {
            newExperimentMission();
        }
        else {
            newGrappleMission();
        }
    }

    public void newCommMission() {
        Instantiate(commMissionPrefab, transform);
        // add to list, popup, etc.
    }

    public void newImageMission() {
        Instantiate(imageMissionPrefab, transform);
        // add to list, popup, etc.
    }

    public void newExperimentMission() {
        Instantiate(experimentMissionPrefab, transform);
        // add to list, popup, etc.
    }

    public void newGrappleMission() {
        Instantiate(grappleMissionPrefab, transform);
        // add to list, popup, etc.
    }

}
