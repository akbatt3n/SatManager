using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satellite : MonoBehaviour {

    public string type;
    public string satName;
    public float fuel = 2000; // measured in m/s deltaV because its a game not a simulator

    // factor to convert km to unity units
    public int scaleFactor = 1000;

    // satellite mass, kg
    public float M = 1000;
    // distance to primary
    public float r; // meters
    public float altitude; // km

    public GameObject primaryObj;
    public Primary primary;

    public GameObject listEntry;

    public Vector3 velocity; // km/s
    public float velMag;
    public Vector3 gravity;
    public Vector3 acceleration;
    public bool circular;
    public bool equitorial;

    int timeScale;
    float threshold = 0.001f;

    // classical orbital elements (COEs)
    public float a;
    public float e;
    public float i;
    public float raan;
    public float argPeriapsis;
    public float tAnomaly;

    // useful for calculating COEs
    public Vector3 eVector; // from primary body to perigee, magnitude = eccentricity
    public Vector3 hVector; // angular velocity
    public Vector3 nVector; // cross product of unit vector straight up and angular velocity. Points perpendicular to orbit path
    public Vector3 posVector; // from primary body to satellite

    // weird shift of decimal places as shown by https://oer.pressbooks.pub/lynnanegeorge/chapter/chapter-3-the-classical-orbital-elements-coes/
    // makes the rest of the math work out though
    float u = (6.67430e-11F * 5.9722e24F) / 1000000000;

    bool manueverQueued = false;

    void Start() {
        // this currently requires the z position be zero
        // if (circular) {
        //     r = 1000 * scaleFactor * transform.position.magnitude;
        //     float v = Mathf.Sqrt(Universe.Instance.G * Universe.Instance.pMass / r);
        //     if (transform.position.x < 0) {
        //         v = -v;
        //     }
        //     velocity.Set(0, 0, v/scaleFactor);
        // }

        primaryObj = GameObject.FindWithTag("earth");
        primary = primaryObj.GetComponent<Primary>();
        scaleFactor = Universe.Instance.scaleFactor;
    }
    
    void Update() {
        // update time scale
        timeScale = Universe.Instance.timeScale;
        GetComponent<TrailRenderer>().time = Universe.Instance.trailTime;

        // update distance from primary's center, in meters
        r = 1000 * scaleFactor * Vector3.Distance(transform.position, primary.transform.position);
        altitude = r/1000 - Universe.Instance.pRadius;

        // check if satellite is too low
        if (altitude <= 0) {
            destroyMyself();
        }

        // get direction, normalize, then scale to equal real-life force of gravity
        posVector = (transform.position - primary.transform.position) * scaleFactor;
        if (posVector == Vector3.zero) {
            return;
        }
        gravity = posVector.normalized;
        gravity = -1 * gravity * (Universe.Instance.G * M * Universe.Instance.pMass / (r*r));

        
        if (timeScale != 0) {
            if (timeScale < 1) timeScale = 1;

            float timeFactor = (Time.deltaTime * Universe.Instance.timeScale);

            // get acceleration due to gravity and apply it
            velocity += gravity/M * timeFactor / 1000;

            // air resistance
            // floats are not accurate enough for the last 2, but maybe this applies some perturbations
            if (altitude < 600) {
                if (altitude < 25)          velocity -= (velocity * 0.05f * timeFactor);
                else if (altitude < 50)     velocity -= (velocity * 0.005f * timeFactor);
                else if (altitude < 75)     velocity -= (velocity * 0.0004f * timeFactor);
                else if (altitude < 100)    velocity -= (velocity * 0.00003f * timeFactor);
                else if (altitude < 150)    velocity -= (velocity * 0.000002f * timeFactor);
                else if (altitude < 200)    velocity -= (velocity * 0.000001f * timeFactor);
                else if (altitude < 400)    velocity -= (velocity * 0.0000001f * timeFactor);
                else                        velocity -= (velocity * 0.00000001f * timeFactor);
            }
            transform.position += velocity * timeFactor / scaleFactor;

        }

        velMag = velocity.magnitude;
        updateOrbitalElements();

        // point at the earth
        transform.LookAt(primary.GetComponent<Transform>());
    }

    void updateOrbitalElements() {

        float v = velocity.magnitude;

        // derive a few vectors from pos & vel vectors
        hVector = Vector3.Cross(velocity, posVector); // angular moment
        nVector = Vector3.Cross(hVector, Vector3.up); // points from primary to ascending node
        eVector = (Vector3.Cross(hVector, velocity) / u) - posVector.normalized; // points from primary to periapsis

        // semi-major axis, in km
        a = -1 * u / (2 * ((v*v / 2) - (u / (r/1000))));

        // eccentricity
        e = eVector.magnitude;

        // inclination
        i = Vector3.Angle(Vector3.up, hVector);

        // check for special conditions that change how orbital elements are calculated
        if (i < 0 + threshold && i > 0 - threshold) equitorial = true;
        else equitorial = false;

        if (e < 0 + threshold && e > 0 - threshold) circular = true;
        else circular = false;


        // RAAN
        // if i=0, then raan is undefined, but I make it -1 for convinience
        if (equitorial) {
            raan = -1;
        }
        else {
            raan = Mathf.Acos(nVector.x / nVector.magnitude) * Mathf.Rad2Deg;
            if (nVector.z < 0) {
                raan = 360 - raan;
            }
        }

        // argument of periapsis
        // undefined in some cases, made -1 for convinience
        if (circular) {
            argPeriapsis = -1;
        }
        else if (equitorial) {
            // argPeriapsis becomes Longitude of Perigee
            argPeriapsis = Vector3.Angle(Vector3.right, eVector);
            if (eVector.z < 0) {
                argPeriapsis = 360 - argPeriapsis;
            }
        }
        else {
            argPeriapsis = Vector3.Angle(nVector, eVector);
            if (eVector.y < 0) {
                argPeriapsis = 360 - argPeriapsis;
            }
        }

        // true anomaly
        if (circular && equitorial) {
            // true anomaly becomes true longitude
            tAnomaly = Vector3.Angle(Vector3.right, posVector);
            if (posVector.z < 0) {
                tAnomaly = 360 - tAnomaly;
            }
        }
        else if (circular) {
            // when circular but not equitorial, true anomaly becomes Argument of Latitude
            tAnomaly = Vector3.Angle(nVector, posVector);
            if (posVector.y < 0) {
                tAnomaly = 360 - tAnomaly;
            }
        }
        else {
            tAnomaly = Mathf.Acos(Vector3.Dot(eVector, posVector) / (eVector.magnitude * posVector.magnitude))  * Mathf.Rad2Deg;
            if (Vector3.Dot(posVector, velocity) < 0) {
                tAnomaly = 360 - tAnomaly;
            }
        }
    }

    public void manuever(string direction, float deltaV) {

        //deltaV comes in as km/s
        // manueverQueued keeps the player from pausing and applying several maneuvers all at once
        if (manueverQueued==false) {

            if (deltaV * 1000 > fuel) {
                Debug.Log("not enough fuel");
            }
            else {

                switch (direction) {
                    case "prograde":
                        // in direction of velocity
                        velocity += deltaV * velocity.normalized;
                        break;
                    case "retrograde":
                        // opposite direction of velocity
                        velocity += deltaV * -velocity.normalized;
                        break;
                    case "normal":
                        // in direction of angular velocity (hVector)
                        velocity += deltaV * hVector.normalized;
                        break;
                    case "antinormal":
                        // opposite direction of angular velocity (hVector)
                        velocity += deltaV * -hVector.normalized;
                        break;
                    case "radial-out":
                        // in direction of the cross product of velocity and angular velocity
                        // should pivot the orbit clockwise about the location of the maneuver
                        velocity += deltaV * (Vector3.Cross(velocity, hVector).normalized);
                        break;
                    case "radial-in":
                        // opposite direction of the cross product of velocity and angular velocity
                        // should pivot the orbit counter-clockwise about the location of the maneuver
                        velocity += deltaV * -(Vector3.Cross(velocity, hVector).normalized);
                        break;
                    default:
                        break;
                }
                fuel -= deltaV * 1000;

                if (timeScale == 0) {
                    manueverQueued = true;
                }
                else {
                    manueverQueued = false;
                }
            }
        }

    }

    public void showOrbit() {
        GetComponent<TrailRenderer>().startWidth = 0.1f;
        GetComponent<LineRenderer>().startWidth = 0.03f;
        switch (type) {
            case "Comm":
                GetComponent<commPayload>().showFootprint();
                break;
            case "Imagery":
                GetComponent<imagePayload>().showFootprint();
                break;
            default:
                break;
        }
    }

    public void hideOrbit() {
        GetComponent<TrailRenderer>().startWidth = 0.0f;
        GetComponent<LineRenderer>().startWidth = 0.0f;
        switch (type) {
            case "Comm":
                GetComponent<commPayload>().hideFootprint();
                break;
            case "Imagery":
                GetComponent<imagePayload>().hideFootprint();
                break;
            default:
                break;
        }
    }

    public void destroyMyself() {
        Destroy(listEntry);
        Destroy(this.gameObject);
    }

}
