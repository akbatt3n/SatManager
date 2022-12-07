using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommMission : MonoBehaviour {

	int sf;

	public GameObject point1;
	public GameObject point2;

	void Start() {
		sf = Universe.Instance.scaleFactor;

		float lon = Random.Range(-179.0f, 180.0f);
		float lat = Random.Range(-89.0f, 89.0f);

		point1.transform.position = new Vector3(6371 / sf, 0, 0);
		point1.transform.Rotate(Vector3.up, lon);
		point1.transform.Rotate(new Vector3(0, 0, 1), lat, Space.Self);


		// this section creates an offset for the 2nd point, in the area of the first, but not too close
		// "overflows" are fine since we're dealing with spheres and degrees
		float offset = 0f;
		// create a somewhat Gaussian distribution for the offset. Maximum 90 degree seperation, but that's pretty unlikely
		// Also a chance to have the offset be negative
		for (int i = 0; i < 5; i++) {
			offset += Random.Range(-2f, 18f);
		}
		// 50/50 chance to flip the sign.
		// For visualizing the probability distriibution, this creates a curve made from 2 gaussian-ish distributions with some overlap.
		// the center of the overlap is the original point
		if (Random.Range(0, 2) == 1) {
			offset *= -1;
		}
		lon += offset;

		// repeat above for latitude. 
		offset = 0f;
		for (int i = 0; i < 5; i++) {
			offset += Random.Range(-2f, 18f);
		}
		if (Random.Range(0, 2) == 1) {
			offset *= -1;
		}
		lat += offset;

		point2.transform.position = new Vector3(6371 / sf, 0, 0);
		point2.transform.Rotate(Vector3.up, lon);
		point2.transform.Rotate(new Vector3(0, 0, 1), lat, Space.Self);
	}

    
}
