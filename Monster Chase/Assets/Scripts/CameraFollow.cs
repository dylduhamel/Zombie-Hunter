using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private Transform player;

    private Vector3 tempPos;

    [SerializeField]
    private float minX, maxX;


    // Start is called before the first frame update
    void Start() {
        // when the game starts it creates a transform object of the player with tag player
        player = GameObject.FindWithTag("Player").transform;
    }

    // is called after all calculations are finished in UPDATE
    void LateUpdate() {
        // if the player dies, exit
        if (!player)
            return;

        CameraMovement();
    }


    void CameraMovement() {
        // current position of camera
        tempPos = transform.position;
        // take the x position and set it to the players current x position
        tempPos.x = player.position.x;

        // making sure camera does not go out of frame
        if (tempPos.x < minX) {
            tempPos.x = minX;
        }
        if (tempPos.x > maxX) {
            tempPos.x = maxX;
        }

        // now set that as the cameras position - following the players x position 
        // note we only use x because we dont want the camera to move when the player jumps
        transform.position = tempPos;
        
    }
}
