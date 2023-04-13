using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZSerializer;

public class TargetDetails : PersistentMonoBehaviour {

    public GameObject satellite;
    Satellite satScript;

    private string location = "θ = ";
    private string orientation = "ω = ";

    public GameObject satName, alt, semiMajor, eccentricity, inclination, raan, argPeri, tAnomaly;

    public void updateValues() {
        satScript = satellite.GetComponent<Satellite>();

        satName.GetComponent<Text>().text = "Name:    " + satScript.satName;

        alt.GetComponent<Text>().text = "Alt.    = " + satScript.altitude.ToString("F1");
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
        if (satScript && this.gameObject.activeInHierarchy) {
            if (satScript.circular && satScript.equitorial) {
                tAnomaly.GetComponent<Text>().text = "l = " + (Mathf.Round(satScript.tAnomaly * 100f) * 0.01f);
            }
            else if (satScript.circular) {
                tAnomaly.GetComponent<Text>().text = "u = " + (Mathf.Round(satScript.tAnomaly * 100f) * 0.01f);
            }
            else {
                tAnomaly.GetComponent<Text>().text = "θ = " + (Mathf.Round(satScript.tAnomaly * 100f) * 0.01f);
            }

            alt.GetComponent<Text>().text = "Alt.    = " + satScript.altitude.ToString("F1");
        }
    }
}
