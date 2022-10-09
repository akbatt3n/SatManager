using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSatMenu : MonoBehaviour {
    
    public TMPro.TMP_InputField nameField;
    public TMPro.TMP_Dropdown typeSelect;
    public TMPro.TMP_InputField altitudeField;
    public GameObject leoButton;
    public GameObject meoButton;
    public GameObject geoButton;
    public TMPro.TMP_InputField inclinationField;
    public TMPro.TMP_InputField raanField;
    public TMPro.TMP_Dropdown fuelSelect;
    public GameObject costDisplay;
    public GameObject launchButton;
    public GameObject cancelButton;

    private int cost;
    private int fuel = 1;
    private int type = 1;
    private int altitude;
    private int inclination;
    private int raan;

    public void updateCost(){

    }

    public void setAltitudeLEO() {
        altitudeField.text = "340";
    }

    public void setAltitudeMEO() {
        altitudeField.text = "20,350";
    }

    public void setAltitudeGEO() {
        altitudeField.text = "35,786";
    }

    public void launch() {

        if (!int.TryParse(altitudeField.text, System.Globalization.NumberStyles.AllowThousands, System.Globalization.CultureInfo.InvariantCulture, out altitude)) {
            Debug.Log("alt field invalid, value: " + altitudeField.text);
            return;
        }
        if (!int.TryParse(inclinationField.text, System.Globalization.NumberStyles.AllowThousands, System.Globalization.CultureInfo.InvariantCulture, out inclination)) {
            Debug.Log("inc field invalid, value: " + inclinationField.text);
            return;
        }
        if (!int.TryParse(raanField.text, System.Globalization.NumberStyles.AllowThousands, System.Globalization.CultureInfo.InvariantCulture, out raan)) {
            Debug.Log("raan field invalid, value: " + raanField.text);
            return;
        }


        switch (fuelSelect.captionText.text) {
            case "Small":
                fuel = 1;
                break;
            case "Medium":
                fuel = 2;
                break;
            case "Large":
                fuel = 3;
                break;
            case "Extra Large":
                fuel = 4;
                break;
            default:
                Debug.Log("fuel field invalid");
                return;
        }

        Universe.Instance.launchSatellite(nameField.text,
                                            typeSelect.captionText.text,
                                            altitude,
                                            inclination,
                                            raan,
                                            fuel,
                                            cost);
    }

}
