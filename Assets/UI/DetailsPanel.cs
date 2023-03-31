using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetailsPanel : MonoBehaviour {
    
    public GameObject satListToggle;
    public GameObject satellite;
    Satellite satScript;

    private string location = "θ = ";
    private string orientation = "ω = ";

    public GameObject satType, satFuel, apo, peri, alt, semiMajor, eccentricity, inclination, raan, argPeri, tAnomaly;

    public void updateValues() {
        satScript = satellite.GetComponent<Satellite>();

        satType.GetComponent<Text>().text = "Payload: " + satScript.type;
        satFuel.GetComponent<Text>().text = "ΔV:      " + satScript.fuel.ToString("F1") + " m/s";

        alt.GetComponent<Text>().text = "Alt. = " + satScript.altitude.ToString("F1");
        eccentricity.GetComponent<Text>().text = "e = " + satScript.e.ToString("F3");
        inclination.GetComponent<Text>().text = "i = " + satScript.i.ToString("F2");

        if (satScript.circular && satScript.equitorial) {
            raan.GetComponent<Text>().text = "Ω = undefined";
            argPeri.GetComponent<Text>().text = "ω = undefined";
            tAnomaly.GetComponent<Text>().text = "l = " + satScript.tAnomaly.ToString("F1");
        }
        else if (satScript.equitorial) {
            raan.GetComponent<Text>().text = "Ω = undefined";
            argPeri.GetComponent<Text>().text = "ϖ = " + satScript.argPeriapsis.ToString("F1");
            tAnomaly.GetComponent<Text>().text = "θ = " + satScript.tAnomaly.ToString("F1");
        }
        else if (satScript.circular) {
            raan.GetComponent<Text>().text = "Ω = " + satScript.raan.ToString("F1");
            argPeri.GetComponent<Text>().text = "ω = undefined";
            tAnomaly.GetComponent<Text>().text = "u = " + satScript.tAnomaly.ToString("F1");
        }
        else {
            raan.GetComponent<Text>().text = "Ω = " + satScript.raan.ToString("F1");
            argPeri.GetComponent<Text>().text = "ω = " + satScript.argPeriapsis.ToString("F1");
            tAnomaly.GetComponent<Text>().text = "θ = " + satScript.tAnomaly.ToString("F1");
        }
    }

    void Update() {
        if (satScript && satListToggle.GetComponent<ToggleGroup>().AnyTogglesOn()) {
            if (satScript.circular && satScript.equitorial) {
                tAnomaly.GetComponent<Text>().text = "l = " + (Mathf.Round(satScript.tAnomaly * 100f) * 0.01f);
            }
            else if (satScript.circular) {
                tAnomaly.GetComponent<Text>().text = "u = " + (Mathf.Round(satScript.tAnomaly * 100f) * 0.01f);
            }
            else {
                tAnomaly.GetComponent<Text>().text = "θ = " + (Mathf.Round(satScript.tAnomaly * 100f) * 0.01f);
            }

            alt.GetComponent<Text>().text = "Alt. = " + satScript.altitude.ToString("F1");
        }

        else if (!satListToggle.GetComponent<ToggleGroup>().AnyTogglesOn()) {
            satType.GetComponent<Text>().text = "Payload: ";
            satFuel.GetComponent<Text>().text = "ΔV:      ";

            alt.GetComponent<Text>().text = "Alt. = ";
            eccentricity.GetComponent<Text>().text = "e = ";
            inclination.GetComponent<Text>().text = "i = ";
            raan.GetComponent<Text>().text = "Ω = ";
            argPeri.GetComponent<Text>().text = "ω = ";
            tAnomaly.GetComponent<Text>().text = "θ = ";

            satellite = null;
            satScript = null;
        }
    }
}
