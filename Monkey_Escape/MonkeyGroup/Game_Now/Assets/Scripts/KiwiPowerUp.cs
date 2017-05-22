using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class KiwiPowerUp : MonoBehaviour {

	public bool powerOn;
	float timeLeft = 300.0f;
	public Text text;


	// Use this for initialization
	void Start () {
		powerOn = false;
	}

	void Update()
	{
		while (powerOn =true) {
			Debug.Log ("Power ON TRUE");
			timeLeft -= Time.deltaTime;
			text.text = "Time Left:" + Mathf.Round (timeLeft);
			if (timeLeft < 0) {
				powerOn = false;
			}
		}
	}
}
