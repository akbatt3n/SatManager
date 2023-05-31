using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {

    public GameObject pauseMenu;
    public bool pauseMenuUp = false;
    
    void Update() {
        if (Input.GetKeyDown("escape")) {
            pauseMenuUp = !pauseMenuUp;
            pauseMenu.SetActive(pauseMenuUp);
            Universe.Instance.pauseGame();
        }
    }
}
