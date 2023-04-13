using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZSerializer;

public class satListEntryScript : PersistentMonoBehaviour {

    public GameObject satellite;
    public GameObject satHighlightToggle;
    public GameObject detailsPanel;
    public GameObject ghost;

    public void toggleHighlight() {
        if (satHighlightToggle.GetComponent<Toggle>().isOn) {
            satellite.GetComponent<Satellite>().showOrbit();
        }
        else { 
            satellite.GetComponent<Satellite>().hideOrbit();
        }
    }

    public void selectSat() {
        if (gameObject.GetComponent<Toggle>().isOn) {
            detailsPanel.GetComponent<DetailsPanel>().satellite = satellite;
            detailsPanel.GetComponent<DetailsPanel>().updateValues();
            ghost.GetComponent<GhostPath>().selectedSat = satellite;
        }
    }
}
