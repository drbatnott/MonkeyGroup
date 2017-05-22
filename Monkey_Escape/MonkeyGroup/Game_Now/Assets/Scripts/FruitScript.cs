using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitScript : MonoBehaviour {
    //sets up rotation for fruit 
	public float speed = 100f;


	void Update ()
	{
		transform.Rotate(Vector3.up, speed * Time.deltaTime);
	}
}
