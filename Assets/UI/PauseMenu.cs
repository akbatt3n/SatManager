using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZSerializer;

public class PauseMenu : MonoBehaviour {
    
    public void save() {
        ZSerialize.SaveScene();
    }

    public void load() {
        ZSerialize.LoadScene();
    }

}
