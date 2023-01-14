using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionEntryScript : MonoBehaviour {
    
    public GameObject mission;
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
        }
    }

}
