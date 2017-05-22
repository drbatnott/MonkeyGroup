using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour {
    public Text highscoreText;

    // Use this for initialization
    void Start () {
        int highscore = PlayerPrefs.GetInt("High Score");
        highscoreText.text = "Highscore: " + highscore.ToString();

    }
	
}
