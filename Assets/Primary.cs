using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Primary : MonoBehaviour {

    
    public float degPerSec = 0.004167F;
    private int sf;

    void Start() {
        sf = Universe.Instance.scaleFactor;
    }

    void Update() {
        transform.Rotate(0, -degPerSec*Time.deltaTime*Universe.Instance.timeScale, 0);
    }
}
