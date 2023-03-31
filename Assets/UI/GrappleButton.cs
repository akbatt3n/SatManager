using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleButton : MonoBehaviour {
    
    public GameObject satellite;

    public void grapple() {
        satellite.GetComponent<grapplePayload>().toggleGrapple();
    }
}
