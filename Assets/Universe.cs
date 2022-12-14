// This script/object is used to hold all the global variables different objects need to interact with
// such as the mass of the Earth, how fast time is moving, and references to other game objects.


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Universe : MonoBehaviour {
    
    // this line makes everything in this class global (singleton)
    public static Universe Instance { get; private set;}

    private void Awake() {

        // make sure there is only 1 universe
        if (Instance != null && Instance != this) {
            Destroy(this);
        }
        else {
            Instance = this;
        }
    }

    // containers for active missions
    public GameObject commMissionBucket;
    public GameObject imageMissionBucket;
    public GameObject grappleMissionBucket;
    public GameObject experimentMissionBucket;

    // gravitational constant
    public float G = 6.67430e-11F;

    // factor to convert km to unity units
    public int scaleFactor = 1000;

    // time multiplier for simulation speed
    public int timeScale = 1;
    public int timeSlider;

    // mass of Earth, kg
    public float pMass = 5.9722e24F;
    // radius of Earth, km
    public float pRadius = 6371F;

    // money the player has, in thousands of dollars
    public int playerMoney = 100;


    //---------------------
    // UI variables
    //---------------------

    public Text speedReadout;
    public Slider speedSlider;
    public GameObject satList;
    public GameObject satContainer;
    public GameObject satListEntryPrefab;
    GameObject satListEntry;
    public GameObject detailsPanel;
    public GameObject ghost;
    
    public GameObject deltaVInput;
    public GameObject directionInput;

    public int trailTime = 50;

    // --------------------
    // satellite prefabs
    // --------------------

    public GameObject imageSatPrefab;
    public GameObject commSatPrefab;
    public GameObject experimentPrefab;
    public GameObject grapplePrefab;

    // --------------------
    // Functions
    // --------------------

    private void Start() {

        // set time scale read out
        changeSpeed();
        if (timeScale != 0) speedReadout.text = "Time Scale: " + timeScale;
        else speedReadout.text = "Paused";

        // clear list
        foreach (Transform child in satList.transform) {
            GameObject.Destroy(child.gameObject);
        }

        // for each satellite object in the container, add its name to the list
        foreach (Transform child in satContainer.transform) {
            string temp = child.GetComponent<Satellite>().satName;
            satListEntry = Instantiate(satListEntryPrefab, satList.transform);
            satListEntry.GetComponentInChildren<Text>().text = temp;
            satListEntry.name = temp;
            satListEntry.GetComponent<satListEntryScript>().satellite = child.gameObject;
            satListEntry.GetComponent<satListEntryScript>().toggleHighlight();
            satListEntry.GetComponent<satListEntryScript>().detailsPanel = detailsPanel;
            satListEntry.GetComponent<satListEntryScript>().ghost = ghost;
            satListEntry.GetComponent<Toggle>().group = satList.GetComponent<ToggleGroup>();
            satListEntry.GetComponent<satListEntryScript>().toggleHighlight();
            child.gameObject.GetComponent<Satellite>().listEntry = satListEntry;
        }
    }

    public void pauseGame() {
        if (timeScale == 0) {
            timeScale = timeSlider;
            speedReadout.text = "Time Scale: " + timeSlider;
        }
        else {
            timeScale = 0;
            speedReadout.text = "Paused";
        }
    }

    public void changeSpeed() {
        switch (speedSlider.value) {
            case 1:
                timeSlider = 1;
                trailTime = 400;
                break;
            case 2:
                timeSlider = 10;
                trailTime = 40;
                break;
            case 3:
                timeSlider = 25;
                trailTime = 15;
                break;
            case 4:
                timeSlider = 50;
                trailTime = 7;
                break;
            case 5:
                timeSlider = 100;
                trailTime = 3;
                break;
            case 6:
                timeSlider = 200;
                trailTime = 1;
                break;
            default:
                timeSlider = 1;
                break;
        }
        if (timeScale != 0) {
            timeScale = timeSlider;
            speedReadout.text = "Time Scale: " + timeSlider;
        }
    }

    public void manuever() {

        if (detailsPanel.GetComponent<DetailsPanel>().satellite == null) {
            Debug.Log("no satellite selected");
            return;
        }

        if (!directionInput.GetComponent<ToggleGroup>().AnyTogglesOn()) {
            Debug.Log("no direction selected");
            return;
        }

        float deltaV = 0f;

        // if input field is empty or not a number, do nothing
        if (float.TryParse(deltaVInput.GetComponent<InputField>().text, System.Globalization.NumberStyles.AllowThousands, System.Globalization.CultureInfo.InvariantCulture, out deltaV)) {
            // input field is m/s, velocity is stored as km/s
            deltaV = deltaV / 1000;
            string direction = "";

            foreach (var thing in directionInput.GetComponent<ToggleGroup>().ActiveToggles()) {
                direction = thing.GetComponent<directionToggle>().direction;
                break;
            }

            detailsPanel.GetComponent<DetailsPanel>().satellite.GetComponent<Satellite>().manuever(direction, deltaV);
            detailsPanel.GetComponent<DetailsPanel>().updateValues();
        }

        // if getting a number from the input field failed:
        else {
            if (deltaVInput.GetComponent<InputField>().text == "" || deltaVInput.GetComponent<InputField>().text == null) {
                Debug.Log("No deltaV specified");
            }
        }
    }

    public void launchSatellite(string name, string type, int alt, int inc, int raan, int fuel, int cost) {

        if (!checkSatNameUnique(name)) {
            Debug.Log("satellite name not unique");
            return;
        }

        float r = alt + pRadius; // r is in km
        float raanRad = (float) raan * Mathf.PI / 180;
        
        GameObject newSatObj;
        switch (type) {
            case "Comm":
                newSatObj = Instantiate(commSatPrefab, satContainer.transform);
                newSatObj.GetComponent<commPayload>().commMissions = commMissionBucket;
                newSatObj.GetComponent<Satellite>().type = type;
                break;
            case "Experiment":
                newSatObj = Instantiate(commSatPrefab, satContainer.transform);
                break;
            case "Imagery":
                newSatObj = Instantiate(imageSatPrefab, satContainer.transform);
                newSatObj.GetComponent<imagePayload>().imageMissions = imageMissionBucket;
                newSatObj.GetComponent<Satellite>().type = type;
                break;
            case "Grappler":
                newSatObj = Instantiate(commSatPrefab, satContainer.transform);
                break;
            default:
                Debug.Log("type field invalid");
                return;
        }
        Satellite newSat = newSatObj.GetComponent<Satellite>();

        Vector3 newPos = new Vector3((r * Mathf.Cos(raanRad)), (0), (r * Mathf.Sin(raanRad))) / scaleFactor;
        newSatObj.transform.position = newPos;

        Vector3 newVelocity;
        newVelocity = Vector3.Cross(newPos, Vector3.up).normalized;
        newVelocity *= Mathf.Sqrt(G * pMass / (r * 1000)) / scaleFactor;
        newVelocity = Quaternion.AngleAxis(-inc, newPos) * newVelocity;
        newSat.velocity = newVelocity;
        newSat.satName = name;

        // deltaV in m/s
        switch (fuel) {
            case 1:
                newSat.fuel = 50;
                break;
            case 2:
                newSat.fuel = 125;
                break;
            case 3:
                newSat.fuel = 500;
                break;
            case 4:
                newSat.fuel = 2000;
                break;
            default:
                Debug.Log("fuel value not mapped properly");
                return;
        }

        satListEntry = Instantiate(satListEntryPrefab, satList.transform);
        satListEntry.GetComponentInChildren<Text>().text = name;
        satListEntry.name = name;
        satListEntry.GetComponent<satListEntryScript>().satellite = newSatObj.gameObject;
        satListEntry.GetComponent<satListEntryScript>().detailsPanel = detailsPanel;
        satListEntry.GetComponent<satListEntryScript>().ghost = ghost;
        satListEntry.GetComponent<Toggle>().group = satList.GetComponent<ToggleGroup>();
        newSat.listEntry = satListEntry;
        // satListEntry.GetComponent<satListEntryScript>().toggleHighlight();
    }

    public bool checkSatNameUnique(string name) {
        foreach (Transform child in satContainer.transform) {
            if (name == child.GetComponent<Satellite>().satName) {
                return false;
            }
        }
        return true;
    }

    public void destroySat(GameObject satelliteObj) {

    }
}
