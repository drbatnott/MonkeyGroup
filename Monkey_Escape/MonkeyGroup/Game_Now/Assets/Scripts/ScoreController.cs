using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{

	//initialise score and highscore 
	public int score;
	public int highscore;
	public Text scoreText;
	public Text highscoreText;
	public Text NewHighscoreText;
	private AudioSource NewHighScoreClip;

	// Use this for initialization
	void Start()
	{

		score = 0;
		highscore = PlayerPrefs.GetInt("High Score");
		SetScoreText();
		SetHighscoreText();

	}

	// Update is called once per frame
	void Update()
	{



		//when player dies set highscore = to that score
		if (score > highscore) 
		{
			highscore = score;
			PlayerPrefs.SetInt("High Score", highscore);
			NewHighscoreText.text = "New Highscore!!";
			NewHighScoreClip = GetComponent<AudioSource>();
			NewHighScoreClip.Play();

			Debug.Log("New high Score is " + highscore + "!!");

		}
	}
	//set score gain for collecting bananas and other fruit
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Coin"))
		{
			other.gameObject.SetActive(false);
			score = score + 10;
			SetScoreText();
		}
		if (other.gameObject.CompareTag("Apple"))
		{
			other.gameObject.SetActive(false);
			score = score + 20;
			SetScoreText();
		}
		if (other.gameObject.CompareTag("Pear"))
		{
			other.gameObject.SetActive(false);
			score = score + 20;
			SetScoreText();
		}
		if (other.gameObject.CompareTag("Kiwi"))
		{
			other.gameObject.SetActive(false);
			score = score + 20;
			SetScoreText();
		}
	}

	//setting score and highscore text on-screen
	void SetScoreText()
	{
		scoreText.text = "Score: " + score.ToString();
	}

	void SetHighscoreText()
	{
		highscoreText.text = "Highscore: " + highscore.ToString();
	}
}

