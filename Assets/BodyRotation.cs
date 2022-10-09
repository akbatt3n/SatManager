using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyRotation : MonoBehaviour {
    
    private float degPerSec = 0.000011415525114155251f;

    // Update is called once per frame
    void Update() {
        transform.Rotate(0, -degPerSec*Time.deltaTime*Universe.Instance.timeScale, 0);
        transform.LookAt(new Vector3(0, 0, 0));
    }
}
