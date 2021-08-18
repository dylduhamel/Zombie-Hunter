using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// this is needed to change scenes
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

    // all methods that use buttons must be public void
    public void PlayGame() {

        // how we get the name of the UI element (button) that is pressed
        string selectedButton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

        if(selectedButton == "Player 1 Button") {
            GameManager.instance.CharIndex = 0;
        } else {
            GameManager.instance.CharIndex = 1;
            
        }
        Debug.Log(GameManager.instance.CharIndex);
        SceneManager.LoadScene("Gameplay");
    }

}
