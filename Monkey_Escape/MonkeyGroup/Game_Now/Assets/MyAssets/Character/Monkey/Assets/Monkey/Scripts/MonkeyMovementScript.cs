using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyMovementScript : MonoBehaviour {

    // Use this for initialization
    private CharacterController controller;
    Animator anim;
    int jumpHash = Animator.StringToHash("Jump");
    int speedHash = Animator.StringToHash("Speed");

    //States
    int runStateHash = Animator.StringToHash("monkey_run");
    int idleStateHash = Animator.StringToHash("monkey_idle");
    int jumpStateHash = Animator.StringToHash("monkey_jump");
    int dieStateHash = Animator.StringToHash("monkey_die");


    void Start()
    {
        print("started");
        anim = GetComponent<Animator>();
        //make player start running on start of game
        //transform.Translate(0f, 0f, 3f * Input.GetAxis("Vertical") * Time.deltaTime);

    }

    // Update is called once per frame
    void Update()
    {

        print("Updated");
        //Needs to be changed to run automatically runs 
        float move = Input.GetAxis("Vertical");
        anim.SetFloat("Speed", move);

       // AnimatorStateInfo stateInfo = anim.GetCurrentAnima && stateInfo.fullPathHash == runStateHastorStateInfo(0);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger(jumpHash);
        }


        //move left/right/up and down
        //transform.Translate(1f * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, 1f * Input.GetAxis("Vertical") * Time.deltaTime);
        //anim.SetFloat("Speed", );

    }
}
