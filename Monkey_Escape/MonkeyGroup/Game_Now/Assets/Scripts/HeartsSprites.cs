using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HeartsSprites : MonoBehaviour {


	public Sprite[] heartSprites;

	public Image heartUI;

	private MonkeyMovement monkey;

	// Use this for initialization
	void Start () {
		monkey = GameObject.FindGameObjectWithTag ("Player").GetComponent<MonkeyMovement> (); 
	}
	
	// Update is called once per frame
	void Update () {

		heartUI.sprite = heartSprites [monkey.lives];
	}
}
