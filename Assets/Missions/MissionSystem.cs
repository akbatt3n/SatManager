using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZSerializer;

public class MissionSystem : PersistentMonoBehaviour {

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
    public GameObject grappleTargetDetailsWindow;

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
        if (Universe.Instance.timeScale == 0) {
            return;
        }
        
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

        float chanceComm = 0.30f;
        float chanceImage = 0.60f;
        float chanceGrapple = 0.10f;

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
        newMission.GetComponent<CommMission>().init();
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
        newMission.GetComponent<ImageMission>().init();
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
        newEntry.GetComponent<MissionEntryScript>().missionSystem = this;

    }

    public void showGrappleTargetParam(GrappleMission mission) {
        grappleTargetDetailsWindow.SetActive(true);
        grappleTargetDetailsWindow.GetComponent<TargetDetails>().satellite = mission.targetObj;
        grappleTargetDetailsWindow.GetComponent<TargetDetails>().updateValues();

    }

    public void hideGrappleTargetParam() {
        grappleTargetDetailsWindow.SetActive(false);
    }
}
