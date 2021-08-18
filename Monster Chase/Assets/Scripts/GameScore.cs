using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameScore : MonoBehaviour {

    private TextMeshProUGUI score;

    // Start is called before the first frame update
    void Start() {
        score = GetComponent<TextMeshProUGUI>();
        score.text = "Score\n0";
    }

    // Update is called once per frame
    void Update() {
        score.text = "Score\n" + PlayerScore.score;
    }
}
