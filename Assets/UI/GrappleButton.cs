using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZSerializer;

public class GrappleButton : PersistentMonoBehaviour {
    
    public GameObject satellite;

    public void grapple() {
        satellite.GetComponent<grapplePayload>().toggleGrapple();
    }
}
