using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionEntryScript : MonoBehaviour {
    
    public GameObject mission;
    public GameObject missionDetailsWindow;
    public string missionType; // will take 1 of 4 values: "comm", "image", "exp", or "grapple"
    public Component detailsType;
    public Component detailsDesc;
    public Component detailsReward;

    public void init() {
        if (missionType == "comm") {
            detailsType = missionDetailsWindow.transform.Find("MissionType").GetComponent<Text>();
            detailsDesc = missionDetailsWindow.transform.Find("Description").GetComponent<Text>();
            detailsReward = missionDetailsWindow.transform.Find("Reward").GetComponent<Text>();
        }
    }

    public void toggleSelection() {
        if (missionType == "comm") {
            if (GetComponent<Toggle>().isOn) {
                mission.GetComponent<CommMission>().selected = true;
                detailsType.text = "Data Relay";
                detailsDesc.text = "Use a communication satellite to relay data between 2 points.";
                detailsReward.text = "$" + mission.GetComponent<CommMission>().reward;
            }
            else {
                mission.GetComponent<CommMission>().selected = false;
                detailsType.text = "";
                detailsDesc.text = "";
                detailsReward.text = "";
            }
            
            mission.GetComponent<CommMission>().toggleHighlight();

        }
    }
}
