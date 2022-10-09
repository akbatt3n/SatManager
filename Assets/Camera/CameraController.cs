using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform cameraOrbit;
    public Transform focus;

    void Start() {
        cameraOrbit.position = focus.position;
    }

    void Update() {
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);

        transform.LookAt(focus.position);
    }

    void updateTarget(GameObject newTarget) {
        // cameraOrbit.position = newTarget.GetComponent<Transform>().position;
        Debug.Log("delete me");
    }
}