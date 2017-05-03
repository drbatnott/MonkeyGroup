using UnityEngine;
using UnityEngine.SceneManagement;

public class MonkeyMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 moveVector;
    private float speed = 5.0f;
    private float verticalVelcoity = 0.0f;
    private float gravity = 12.0f;
    public AudioSource audioClip;
    public GameObject camera;
    public static bool invincible;

    private int lives = 3;
    private float timeLimit = 10.0f;
    // Use this for initialization

    private bool jumpState = false;
    private bool timerState = false;

    
    //Starting Position
    Vector3 myPosition;
    int lane; 

    Animator anim;
   
    int jumpHash = Animator.StringToHash("Jump");
    int speedHash = Animator.StringToHash("Speed");
    int dieHash = Animator.StringToHash("Die");
    int deadStateHash = Animator.StringToHash("DeadState");

    //States
    int runStateHash = Animator.StringToHash("monkey_run");
    int idleStateHash = Animator.StringToHash("monkey_idle");
    int jumpStateHash = Animator.StringToHash("monkey_jump");
    int dieStateHash = Animator.StringToHash("monkey_die");


    private float animationDuration = 3.0f;
    void Start()
    {
        myPosition = transform.position;
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        lane = 0;

        
    }

    // Update is called once per frame
    void Update ()
    {
        speed += 0.01f;


        if (Time.time < animationDuration)
        {

            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;

        }


        //Infinite Move
        moveVector = Vector3.zero;
        anim.SetFloat("Speed", speed);

        //Gravity Check
        if (controller.isGrounded)
        {
            verticalVelcoity = -2.5f;
            jumpState = false;

        }
        else
        {
            verticalVelcoity -= gravity * Time.deltaTime;
        }



        //X LEFT and Right
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;

        //Y UP and Down
        moveVector.y = verticalVelcoity;

        //Z Forward and back
        moveVector.z = speed;
        controller.Move(moveVector * Time.deltaTime);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpState == false) {
                jump();
            }
           
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            if (lane > -2)
            {
                lane -= 2;
            }
        }

        if(Input.GetKeyDown(KeyCode.RightArrow)) {
            if (lane < 2)
            {
                lane += 2;
            }
        }


        Vector3 newPosition = transform.position;
        newPosition.x = lane;
        transform.position = newPosition;

    }

    private void jump() {
        jumpState = true;
        PlaySound(1);
        anim.SetTrigger(jumpHash);
        transform.position = transform.position + new Vector3(0, 1.5f, 5);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        switch (hit.transform.tag) {

            case "Obstacle":
                death(hit);
                break;
            case "Coin":
                collectCoin(hit);
                break;
            case "Bush":
                break;
            case "Kiwi":
                kiwi();
                break;
            case "Pear":
                pear();
                break;
            case "Apple":
                apple(hit);
                break;
            case "Strawberry":
                strawberry();
                break;
            default:
                Debug.Log("default");
                break;         
        }
    }

    private void death(ControllerColliderHit hit)
    {


        CameraMotor.shake = true;


        /*
        if (lives == 0)
        {
            speed = 0f;
            jumpState = true;
            anim.SetTrigger(dieHash);
            if (!this.anim.GetCurrentAnimatorStateInfo(0).IsName("monkey_die"))
            {
                loadByIndex(2);
            }
        }
        else
        {
            lives--;
            //invincible = true;
            speed = 5.0f;
            Destroy(hit.gameObject);
            CameraMotor.shake = true;

        }
        */


    }

    void PlaySound(int clip)
    {
        audioClip = GetComponent<AudioSource>();
        audioClip.Play();
    }
    private void collectCoin(ControllerColliderHit hit) {
        PlaySound(0);
        Destroy(hit.gameObject);

    }

    public void loadByIndex(int sceneIndex) {

        SceneManager.LoadScene(sceneIndex);
          
    }

    public void strawberry() {
        //Double points per banana

    }
    public void apple(ControllerColliderHit hit) {
        Destroy(hit.gameObject);
        //shield

    }
    public void kiwi() {
        //speed up
        speed += 5;
        timerState = true;

      


    }  public void pear() {
        //more life 

        lives++;

    }



}