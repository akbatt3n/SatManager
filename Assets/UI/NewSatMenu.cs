using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using ZSerializer;

public class NewSatMenu : PersistentMonoBehaviour {
    
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
        if (!parseCostFields()) {
            return;
        }

        cost = (int) (Mathf.Pow(altitude, 2f) / 2f);
        cost = (int) (cost * Mathf.Max(1f, fuel*0.75f));
        costDisplay.GetComponent<Text>().text = cost.ToString("C0", CultureInfo.CurrentCulture) + "K";
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

    public bool parseNonCostFields() {
        if (nameField.text == "") {
            Debug.Log("Name field is empty");
            return false;
        }

        if (!int.TryParse(inclinationField.text, System.Globalization.NumberStyles.AllowThousands, System.Globalization.CultureInfo.InvariantCulture, out inclination)) {
            return false;
        }
        if (!int.TryParse(raanField.text, System.Globalization.NumberStyles.AllowThousands, System.Globalization.CultureInfo.InvariantCulture, out raan)) {
            return false;
        }

        return true;
    }

    public bool parseCostFields() {
        if (!int.TryParse(altitudeField.text, System.Globalization.NumberStyles.AllowThousands, System.Globalization.CultureInfo.InvariantCulture, out altitude)) {
            return false;
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
                return false;
        }

        return true;
    }

    public void launch() {

        if (parseNonCostFields()) {
            updateCost();
            Universe.Instance.launchSatellite(true,
                                            nameField.text,
                                            typeSelect.captionText.text,
                                            altitude,
                                            inclination,
                                            raan,
                                            fuel,
                                            cost);
        }
    }

}
