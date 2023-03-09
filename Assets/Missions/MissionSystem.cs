using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionSystem : MonoBehaviour {

    public int newMissionTime; // time before a new mission gets added in sec
    public GameObject commMissionPrefab;
    public GameObject imageMissionPrefab;
    public GameObject grappleMissionPrefab;

    public GameObject commMissionBucket;
    public GameObject imageMissionBucket;
    public GameObject grappleMissionBucket;

    public GameObject missionListEntryPrefab;
    public GameObject missionList;
    public GameObject missionDetailsWindow;

    public List<string> targetNames = new List<string>();
    public GameObject grappleTargetPrefab;

    // only 1 of these should be set to true at a time
    public bool commOnly = false;
    public bool imageOnly = false;
    public bool grappleOnly = false;

    void Start() {
        InvokeRepeating("timerUpdate", 5f, 1f);
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
        else if (imageOnly) {
            newImageMission();
            return;
        }
        else if (grappleOnly) {
            newGrappleMission();
            return;
        }

        float chanceComm = 0.50f;
        float chanceImage = 0.30f;
        float chanceGrapple = 0.20f;

        float roll = Random.Range(0f, 1f);

        if (roll < chanceComm) {
            newCommMission();
        }
        else if (roll < chanceComm + chanceImage) {
            newImageMission();
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
        newMission.GetComponent<CommMission>().listEntry = newEntry;
    }

    public void newImageMission() {
        GameObject newMission = Instantiate(imageMissionPrefab, imageMissionBucket.transform);
        GameObject newEntry = Instantiate(missionListEntryPrefab, missionList.transform);
        newEntry.GetComponentInChildren<Text>().text = "Imagery";
        newEntry.GetComponent<Toggle>().group = missionList.GetComponent<ToggleGroup>();
        newEntry.GetComponent<MissionEntryScript>().mission = newMission;
        newEntry.GetComponent<MissionEntryScript>().missionType = "image";
        newEntry.GetComponent<MissionEntryScript>().missionDetailsWindow = missionDetailsWindow;
        newMission.GetComponent<ImageMission>().listEntry = newEntry;
    }

    public void newGrappleMission() {
        GameObject newMission = Instantiate(grappleMissionPrefab, grappleMissionBucket.transform);
        newMission.GetComponent<GrappleMission>().msysObj = gameObject;
        newMission.GetComponent<GrappleMission>().targetPrefab = grappleTargetPrefab;
        GameObject newEntry = Instantiate(missionListEntryPrefab, missionList.transform);
        newEntry.GetComponentInChildren<Text>().text = "Object Grapple";
        newEntry.GetComponent<Toggle>().group = missionList.GetComponent<ToggleGroup>();
        newEntry.GetComponent<MissionEntryScript>().mission = newMission;
        newEntry.GetComponent<MissionEntryScript>().missionType = "grapple";
        newEntry.GetComponent<MissionEntryScript>().missionDetailsWindow = missionDetailsWindow;

    }

}
