using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grapplePayload : MonoBehaviour {

    public GameObject grappleMissions;
    public float maxDistanceMm = 0.001f; // Mm = 1000Km
    public GameObject heldObject;
    
    public void toggleGrapple() {
        if (heldObject == null) {
            foreach (Transform mission in grappleMissions.transform) {
                // "mission" var is the transform, need to get the parent game object, then the script, 
                // then the var that references the target satellite object, then it's position
                GrappleMission temp = mission.parent.GetComponent<GrappleMission>();
                if (Vector3.Distance(transform.position, temp.targetObj.transform.position) > maxDistanceMm) {
                    break;
                }
                heldObject = temp.gameObject;
                enabled = true;
            }
        }
        else {
            heldObject = null;
            enabled = false;
        }
    }

    void Update() {

    }
}
