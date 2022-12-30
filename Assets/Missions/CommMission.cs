using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommMission : MonoBehaviour {

	int sf;

	// reward in thousands of dollars. needs to be balanced
	public int minReward = 10;
	public int maxReward = 200;

	public GameObject point1;
	public GameObject point2;

	public int reward;

	float maxOffset = 10f;
	float minOffset = -2f;
	int offsetRolls = 5;

	void Start() {
		sf = Universe.Instance.scaleFactor;

		float lon = Random.Range(-179.0f, 180.0f);
		float lat = Random.Range(-89.0f, 89.0f);

		// point the X-axis in a random direction (from above), then move forward to the surface of the Earth
		point1.transform.Rotate(new Vector3(0, 1, 0), lon);
		point1.transform.Rotate(new Vector3(0, 0, 1), lat, Space.Self);
		point1.transform.Translate((6371f / sf), 0, 0, Space.Self);


		// this section creates an offset for the 2nd point, in the area of the first, but not too close
		// "overflows" are fine since we're dealing with spheres and degrees
		float offset = 0f;
		// create a somewhat Gaussian distribution for the offset. Maximum 90 degree separation, but that's pretty unlikely
		// Also a chance to have the offset be negative
		for (int i = 0; i < offsetRolls; i++) {
			offset += Random.Range(minOffset, maxOffset);
		}
		// 50/50 chance to flip the sign.
		// For visualizing the probability distribution, this creates a curve made from 2 Gaussian-ish distributions with some overlap.
		// the center of the overlap is the original point
		if (Random.Range(0, 2) == 1) {
			offset *= -1;
		}
		lon += offset;

		// repeat above for latitude. 
		offset = 0f;
		for (int i = 0; i < offsetRolls; i++) {
			offset += Random.Range(minOffset, maxOffset);
		}
		if (Random.Range(0, 2) == 1) {
			offset *= -1;
		}
		lat += offset;

		point2.transform.Rotate(new Vector3(0, 1, 0), lon);
		point2.transform.Rotate(new Vector3(0, 0, 1), lat, Space.Self);
		point2.transform.Translate((6371f / sf), 0, 0, Space.Self);

		reward = Random.Range(minReward, maxReward+1);
	}

	public void complete() {
		// reward money
		// remove list entry
		// delete self
		Destroy(this.gameObject);
	}
    
}
