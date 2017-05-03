using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bananasScript : MonoBehaviour {

    private CharacterController controller;

   
    // Use this for initialization
    void Start () {
        Debug.Log("Banana Script started");
        controller = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.point.z > transform.position.z + controller.radius)
        {

            collect();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        collect();
    }

    private void collect() {

        //Update High Score
        Debug.Log("Banana collected");

        Destroy(gameObject);
    }
}
