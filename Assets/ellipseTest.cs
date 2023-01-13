using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent (typeof(LineRenderer))]
public class ellipseTest : MonoBehaviour {

    public float A = 10;
    public float B = 20;
    public float C;

    public float width = 1;
    public int resolution = 500;

    public float testArgPeri = 0;
    public float testRaan = 0;
    public float testInc = 0;

    // factor to convert km to unity units
    int sf = 1000;

    Vector3[] positions;
    LineRenderer self_lineRenderer;

    void OnValidate() {
     UpdateEllipse();
    }

    void Update() {
        sf = 1000;
        UpdateEllipse();
    }

    public void UpdateEllipse() {
        
        // A = 10;
        // B = 20;

        C = Mathf.Sqrt(Mathf.Abs((A*A) - (B*B)));


        if (self_lineRenderer == null) self_lineRenderer = GetComponent<LineRenderer>();
        
        self_lineRenderer.positionCount = resolution + 3;
        self_lineRenderer.startWidth = width;

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
        pointPosition.x -= C/sf;

        // create quaternion to hold rotations
        Quaternion q;

        // rotate i degrees around z-axis (sets inclination)
        q = Quaternion.AngleAxis(testInc, new Vector3(0, 0, 1));

        // rotate argument of periapsis degrees around y-axis (sets argPeriapsis)
        q *= Quaternion.AngleAxis(-testArgPeri-90, new Vector3(0, 1, 0));

        // apply all these rotations to the point before applying RAAN
        // I think of it as if stacking rotations on a single quaternion rotates the axes too
        pointPosition = q * pointPosition;

        // rotate RAAN degrees
        q = Quaternion.AngleAxis(-testRaan-90, new Vector3(0, 1, 0));
        pointPosition = q * pointPosition;

        self_lineRenderer.SetPosition(index, pointPosition);
    }


}