using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {
    private static MusicManager instance;

    private void Awake () {
        // Does not destroy the music object playing during on the main menu
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad (instance);
        } else {
            Destroy (gameObject);
        }
    }

}