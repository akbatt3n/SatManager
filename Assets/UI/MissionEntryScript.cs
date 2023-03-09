using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionEntryScript : MonoBehaviour {
    
    public GameObject mission;
    public GameObject missionDetailsWindow;
    public string missionType; // will take 1 of 4 values: "comm", "image", "exp", or "grapple"
    public Text detailsType;
    public Text detailsDesc;
    public Text detailsReward;

    void Start() {
        detailsType = missionDetailsWindow.transform.Find("MissionType").GetComponent<Text>();
        detailsDesc = missionDetailsWindow.transform.Find("Description").GetComponent<Text>();
        detailsReward = missionDetailsWindow.transform.Find("Reward").GetComponent<Text>();
    }

    public void toggleSelection() {
        // 1st if/else figure out the type of mission, as the different mission types have different component names
        // Then, sets or erases text if the entry is selected or not.
        // Finally, toggles the sphere that represents the mission location (comm & image missions only)

        if (missionType == "comm") {
            if (GetComponent<Toggle>().isOn) {
                mission.GetComponent<CommMission>().selected = true;
                detailsType.text = "Data Relay";
                detailsDesc.text = "Use a communication satellite to relay data between 2 points.";
                detailsReward.text = "$" + mission.GetComponent<CommMission>().reward + "K";
            }
            else {
                mission.GetComponent<CommMission>().selected = false;
                detailsType.text = "";
                detailsDesc.text = "";
                detailsReward.text = "";
            }
            mission.GetComponent<CommMission>().toggleHighlight();
        }

        else if (missionType == "image") {
            if (GetComponent<Toggle>().isOn) {
                mission.GetComponent<ImageMission>().selected = true;
                detailsType.text = "Ground Imaging";
                detailsDesc.text = "Use a imaging satellite to take a picture of a specific point.";
                detailsReward.text = "$" + mission.GetComponent<ImageMission>().reward + "K";
            }
            else {
                mission.GetComponent<ImageMission>().selected = false;
                detailsType.text = "";
                detailsDesc.text = "";
                detailsReward.text = "";
            }
            mission.GetComponent<ImageMission>().toggleHighlight();
        }

        else if (missionType == "exp") {
            if (GetComponent<Toggle>().isOn) {
                mission.GetComponent<ExperimentMission>().selected = true;
                detailsType.text = "Experiment";
                detailsDesc.text = "Gather data from a satellite within the given parameters.";
                detailsReward.text = "$" + mission.GetComponent<ExperimentMission>().reward + "K";
            }
            else {
                mission.GetComponent<ExperimentMission>().selected = false;
                detailsType.text = "";
                detailsDesc.text = "";
                detailsReward.text = "";
            }
            mission.GetComponent<ExperimentMission>().toggleHighlight();
        }

        else if (missionType == "grapple") {
            if (GetComponent<Toggle>().isOn) {
                mission.GetComponent<GrappleMission>().selected = true;
                detailsType.text = "Grapple";
                detailsDesc.text = "Approach another satellite and move it to the target orbit.";
                detailsReward.text = "$" + mission.GetComponent<GrappleMission>().reward + "K";
            }
            else {
                mission.GetComponent<GrappleMission>().selected = false;
                detailsType.text = "";
                detailsDesc.text = "";
                detailsReward.text = "";
            }
            mission.GetComponent<GrappleMission>().toggleHighlight();
        }
    }

    public void delete() {
        detailsType.text = "";
        detailsDesc.text = "";
        detailsReward.text = "";
        Destroy(this.gameObject);
    }
}
