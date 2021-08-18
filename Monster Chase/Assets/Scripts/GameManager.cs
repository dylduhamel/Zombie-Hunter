using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    // this allows us to edit the values of this class without making an external instance (in main menu controller)
    // its also important because it stores the value so we can access it in the other scene
    public static GameManager instance;

    [SerializeField]
    private GameObject[] characters;

    // encapsulation
    private int _charIndex;
    public int CharIndex {
        get { return _charIndex; }
        set { this._charIndex = value; }
    }


    private void Awake() {
        if (instance == null) {
            instance = this;
            // prevents this object from getting destroyed when scenes change
            // game manager is the game object that is holding this script
            DontDestroyOnLoad(gameObject);
    } else {
            Destroy(gameObject);
        }
    }
    
    void OnLevelFinishedLoading(UnityEngine.SceneManagement.Scene scene, LoadSceneMode mode) {
        if (scene.name == "Gameplay") {
            Instantiate(characters[CharIndex]);
        }
    }

    private void OnEnable() {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    private void OnDisable() {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    
}
