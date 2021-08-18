using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerScore : MonoBehaviour {

    // making a accessable score value to be updated by GameScore
    public static int score;

    private string ENEMY_TAG = "Enemy";
    // Start is called before the first frame update
    void Start() {
      
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.GetType() == typeof(BoxCollider2D)) {
            if (collision.gameObject.CompareTag(ENEMY_TAG)) {
                score++;           
            }
        }
    }
}
