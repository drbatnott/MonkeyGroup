using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;


public class CustomMovt : MonoBehaviour
{

    // Use this for initialization
    //public Vector3 jumpForce = new Vector3(0, 300, 0);

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //make player start running on start of game
        //transform.Translate(0f, 0.2f * Time.deltaTime, 0f);

        //move left/right/up and down
        transform.Translate(1f * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, 1f * Input.GetAxis("Vertical") * Time.deltaTime);

        //Jump
        if (Input.GetKey("space"))
        {
            //m_Rigidbody.velocity = Vector3.zero;
            //m_Rigidbody.AddForce(jumpForce);
            
        }

    }

}