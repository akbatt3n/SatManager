using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionSystem : MonoBehaviour {

    public int newMissionTime; // time before a new mission gets added in sec
    public GameObject commMissionPrefab;
    public GameObject imageMissionPrefab;
    public GameObject experimentMissionPrefab;
    public GameObject grappleMissionPrefab;

    public GameObject commMissionBucket;
    public GameObject imageMissionBucket;
    public GameObject experimentMissionBucket;
    public GameObject grappleMissionBucket;

    public GameObject missionListEntryPrefab;
    public GameObject missionList;
    public GameObject missionDetailsWindow;

    public bool commOnly = false;

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
        if (commOnly) {
            newCommMission();
            return;
        }

        float chanceComm = 0.40f;
        float chanceImage = 0.20f;
        float chanceExp = 0.30f;
        float chanceGrapple = 0.10f;

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
        GameObject newMission = Instantiate(commMissionPrefab, commMissionBucket.transform);
        GameObject newEntry = Instantiate(missionListEntryPrefab, missionList.transform);
        newEntry.GetComponentInChildren<Text>().text = "Data Relay";
        newEntry.GetComponent<Toggle>().group = missionList.GetComponent<ToggleGroup>();
        newEntry.GetComponent<MissionEntryScript>().mission = newMission;
        newEntry.GetComponent<MissionEntryScript>().missionType = "comm";
        newEntry.GetComponent<MissionEntryScript>().missionDetailsWindow = missionDetailsWindow;
    }

    public void newImageMission() {
        GameObject newMission = Instantiate(imageMissionPrefab, imageMissionBucket.transform);
        GameObject newEntry = Instantiate(missionListEntryPrefab, missionList.transform);
        newEntry.GetComponentInChildren<Text>().text = "Imagery";
        newEntry.GetComponent<Toggle>().group = missionList.GetComponent<ToggleGroup>();
        newEntry.GetComponent<MissionEntryScript>().mission = newMission;
        newEntry.GetComponent<MissionEntryScript>().missionType = "image";
        newEntry.GetComponent<MissionEntryScript>().missionDetailsWindow = missionDetailsWindow;
    }

    public void newExperimentMission() {
        GameObject newMission = Instantiate(experimentMissionPrefab, experimentMissionBucket.transform);
        GameObject newEntry = Instantiate(missionListEntryPrefab, missionList.transform);
        newEntry.GetComponentInChildren<Text>().text = "Experiment";
        newEntry.GetComponent<Toggle>().group = missionList.GetComponent<ToggleGroup>();
        newEntry.GetComponent<MissionEntryScript>().mission = newMission;
        newEntry.GetComponent<MissionEntryScript>().missionType = "exp";
        newEntry.GetComponent<MissionEntryScript>().missionDetailsWindow = missionDetailsWindow;
    }

    public void newGrappleMission() {
        GameObject newMission = Instantiate(grappleMissionPrefab, grappleMissionBucket.transform);
        GameObject newEntry = Instantiate(missionListEntryPrefab, missionList.transform);
        newEntry.GetComponentInChildren<Text>().text = "Object Grapple";
        newEntry.GetComponent<Toggle>().group = missionList.GetComponent<ToggleGroup>();
        newEntry.GetComponent<MissionEntryScript>().mission = newMission;
        newEntry.GetComponent<MissionEntryScript>().missionType = "grapple";
        newEntry.GetComponent<MissionEntryScript>().missionDetailsWindow = missionDetailsWindow;
    }

}
