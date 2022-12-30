// a copy of OrbitPath.cs, but designed to work with an external object instead of being attached to a satellite

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(LineRenderer))]
public class GhostPath : MonoBehaviour {

    public float A;
    public float B;
    public float C;
    public int resolution = 500;
    public GameObject selectedSat;
    public GameObject maneuverVelocity;
    public GameObject maneuverDirection;

    private Vector3 satelliteVelocity;
    private float maneuverDeltaV;
    private Vector3 postManeuverVelocity;
    private string direction;

    private float e;
    private float i;
    private float argPeriapsis;
    private float raan;
    private Vector3 hVector;
    private Vector3 eVector;
    private Vector3 nVector;

    private float u;
    private bool showGhost = false;

    // factor to convert km to unity units
    int sf;

    Vector3[] positions;
    LineRenderer self_lineRenderer;

    void Start() {
        u = (Universe.Instance.G * Universe.Instance.pMass) / 1000000000;
        sf = Universe.Instance.scaleFactor;
    }

    void Update() {
        if ( (selectedSat != null) && (maneuverVelocity.GetComponent<InputField>().text != "") && (maneuverDirection.GetComponent<ToggleGroup>().AnyTogglesOn()) ) {
            
            if (float.TryParse(maneuverVelocity.GetComponent<InputField>().text, System.Globalization.NumberStyles.AllowThousands, System.Globalization.CultureInfo.InvariantCulture, out maneuverDeltaV)) {
                maneuverDeltaV = maneuverDeltaV / 1000;
                GetComponent<LineRenderer>().startWidth = 0.1f;
                showGhost = true;

            }
            else {
                return;
            }

            foreach (var thing in maneuverDirection.GetComponent<ToggleGroup>().ActiveToggles()) {
                direction = thing.GetComponent<directionToggle>().direction;
                break;
            }

            satelliteVelocity = selectedSat.GetComponent<Satellite>().velocity;
            postManeuverVelocity = satelliteVelocity;

            switch (direction) {
                    case "prograde":
                        // in direction of velocity
                        postManeuverVelocity += maneuverDeltaV * satelliteVelocity.normalized;
                        break;
                    case "retrograde":
                        // opposite direction of velocity
                        postManeuverVelocity += maneuverDeltaV * -satelliteVelocity.normalized;
                        break;
                    case "normal":
                        // in direction of angular velocity (hVector)
                        postManeuverVelocity += maneuverDeltaV * selectedSat.GetComponent<Satellite>().hVector.normalized;
                        break;
                    case "antinormal":
                        // opposite direction of angular velocity (hVector)
                        postManeuverVelocity += maneuverDeltaV * -selectedSat.GetComponent<Satellite>().hVector.normalized;
                        break;
                    case "radial-out":
                        // in direction of the cross product of velocity and angular velocity
                        // should pivot the orbit clockwise about the location of the manuever
                        postManeuverVelocity += maneuverDeltaV * (Vector3.Cross(satelliteVelocity, selectedSat.GetComponent<Satellite>().hVector).normalized);
                        break;
                    case "radial-in":
                        // opposite direction of the cross product of velocity and angular velocity
                        // should pivot the orbit counter-clockwise about the location of the manuever
                        postManeuverVelocity += maneuverDeltaV * -(Vector3.Cross(satelliteVelocity, selectedSat.GetComponent<Satellite>().hVector).normalized);
                        break;
                    default:
                        break;
                }

            UpdateEllipse();
        }
        else if (showGhost){
            GetComponent<LineRenderer>().startWidth = 0.0f;
            showGhost = false;
        }
    }

    public void UpdateEllipse() {

        // calculate post-maneuver vectors and COEs
        hVector = Vector3.Cross(postManeuverVelocity, selectedSat.GetComponent<Satellite>().posVector);
        eVector = (Vector3.Cross(hVector, postManeuverVelocity) / u) - selectedSat.GetComponent<Satellite>().posVector.normalized;
        nVector = Vector3.Cross(hVector, Vector3.up);
        e = eVector.magnitude;
        i = Vector3.Angle(Vector3.up, hVector);
        argPeriapsis = Vector3.Angle(nVector, eVector);
        if (eVector.y < 0) {
            argPeriapsis = 360 - argPeriapsis;
        }

        raan = Mathf.Acos(nVector.x / nVector.magnitude) * Mathf.Rad2Deg;
        if (nVector.z < 0) {
            raan = 360 - raan;
        }

        // calculate variables to draw ellipse
        A = -1 * u / (2 * ((postManeuverVelocity.magnitude*postManeuverVelocity.magnitude / 2) - (u / (selectedSat.GetComponent<Satellite>().r/1000))));
        B = A * Mathf.Sqrt(1 - Mathf.Pow(e, 2));
        C = Mathf.Sqrt(Mathf.Abs((A*A) - (B*B)));

        // set up line renderer reference if it doesn't exist
        if (self_lineRenderer == null) {
            self_lineRenderer = GetComponent<LineRenderer>();
            self_lineRenderer.positionCount = resolution + 3;
        }

        // loop through to add all points on ellipse
        AddPoint(0f, 0);
        for (int i = 1; i <= resolution + 1; i++) {
            AddPoint((float)i / (float)(resolution) * 2f * Mathf.PI, i);
        }
        AddPoint(0f, resolution + 2);
    }

    // adds a point to ellipse
    // anomaly should be in radians, and represents the true anomaly for each point in the ellipse
    void AddPoint(float anomaly, int index) {

        Vector3 pointPosition;

        // create points on ellipse
        // the /sf converts A and B from km to unity units
        pointPosition = new Vector3(A/sf * Mathf.Cos(anomaly), 0f, B/sf * Mathf.Sin(anomaly));

        // offset by C
        pointPosition.x += C/sf;

        // create quaternion to hold rotations
        Quaternion q;

        // rotate i degrees around z-axis (sets inclination)
        q = Quaternion.AngleAxis(i, new Vector3(0, 0, 1));

        // rotate argument of periapsis degrees around y-axis (sets argPeriapsis)
        q *= Quaternion.AngleAxis(-argPeriapsis - 90, new Vector3(0, 1, 0));

        // apply all these rotations to the point before applying RAAN
        // I think of it as if stacking rotations on a single quaternion rotates the axes too
        pointPosition = q * pointPosition;

        // rotate RAAN degrees
        q = Quaternion.AngleAxis(-raan - 90, new Vector3(0, 1, 0));
        pointPosition = q * pointPosition;

        self_lineRenderer.SetPosition(index, pointPosition);
    }

}