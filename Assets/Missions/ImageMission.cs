using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageMission : MonoBehaviour {

    int sf;

    // reward in thousands of dollars. needs to be balanced
    public int minReward = 10;
    public int maxReward = 200;

    public int reward;

    float maxOffset = 10f;
    float minOffset = -2f;
    int offsetRolls = 5;

    void Start() {
        sf = Universe.Instance.scaleFactor;

        float lon = Random.Range(-179.0f, 180.0f);
        float lat = Random.Range(-89.0f, 89.0f);

        // point the X-axis in a random direction (from above), then move forward to the surface of the Earth
        transform.Rotate(new Vector3(0, 1, 0), lon);
        transform.Rotate(new Vector3(0, 0, 1), lat, Space.Self);
        transform.Translate((6371f / sf), 0, 0, Space.Self);

        reward = Random.Range(minReward, maxReward+1);
    }

    public void complete() {
        // reward money
        // remove list entry
        // delete self
        Destroy(this.gameObject);
    }
    
}
