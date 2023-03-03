using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionEntryScript : MonoBehaviour {
    
    public GameObject mission;
    public GameObject missionDetailsWindow;
    public string missionType; // will take 1 of 4 values: "comm", "image", "exp", or "grapple"

    public void toggleSelection() {
        if (missionType == "comm") {
            if (GetComponent<Toggle>().isOn) {
                mission.GetComponent<CommMission>().selected = true;
            }
            else {
                mission.GetComponent<CommMission>().selected = false;
            }
            
            mission.GetComponent<CommMission>().toggleHighlight();

            missionDetailsWindow.transform.Find("MissionType").GetComponent<Text>().text = "Data Relay";
            missionDetailsWindow.transform.Find("Description").GetComponent<Text>().text = "Use a communication satellite to relay data between 2 points.";
            missionDetailsWindow.transform.Find("Reward").GetComponent<Text>().text = "$" + mission.GetComponent<CommMission>().reward;
        }

    }

}
