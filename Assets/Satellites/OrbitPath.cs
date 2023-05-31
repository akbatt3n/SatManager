using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZSerializer;

[RequireComponent (typeof(LineRenderer))]
public class OrbitPath : PersistentMonoBehaviour {

	public float A;
	public float B;
	public float C;
	public int resolution = 500;

	// factor to convert km to unity units
	int sf;

	Vector3[] positions;
	LineRenderer self_lineRenderer;

	void Update() {
		sf = Universe.Instance.scaleFactor;
		UpdateEllipse();
	}

	public void UpdateEllipse() {
		A = gameObject.GetComponent<Satellite>().a;
		B = A * Mathf.Sqrt(1 - Mathf.Pow(gameObject.GetComponent<Satellite>().e, 2));
		C = Mathf.Sqrt(Mathf.Abs((A*A) - (B*B)));

		if (self_lineRenderer == null) {
			self_lineRenderer = GetComponent<LineRenderer>();
			self_lineRenderer.positionCount = resolution + 3;
		}

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
        q = Quaternion.AngleAxis(GetComponent<Satellite>().i, new Vector3(0, 0, 1));

        // rotate argument of periapsis degrees around y-axis (sets argPeriapsis)
        q *= Quaternion.AngleAxis(-GetComponent<Satellite>().argPeriapsis-90, new Vector3(0, 1, 0));

        // apply all these rotations to the point before applying RAAN
        // I think of it as if stacking rotations on a single quaternion rotates the axes too
        pointPosition = q * pointPosition;

        // rotate RAAN degrees
        q = Quaternion.AngleAxis(-GetComponent<Satellite>().raan-90, new Vector3(0, 1, 0));
        pointPosition = q * pointPosition;

        self_lineRenderer.SetPosition(index, pointPosition);
	}


}