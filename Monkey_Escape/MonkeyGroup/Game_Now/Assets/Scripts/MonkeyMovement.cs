using UnityEngine;
using UnityEngine.SceneManagement;

public class MonkeyMovement : MonoBehaviour
{
    //initialise player movement
    private CharacterController controller;
	private ScoreController scoreController;
    private Vector3 moveVector;
    private float speed = 5.0f;
    private float verticalVelcoity = 0.0f;
    private float gravity = 12.0f;
    //initialise audio clips
    public AudioClip[] audioClip;
    //initialise camera object
    public GameObject camera;
	public KiwiPowerUp kiwiPowerup;



    public static bool invincible;

    public int lives = 5;
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
		scoreController = GetComponent<ScoreController> ();
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
		kiwiPowerup = GetComponent<KiwiPowerUp> ();


        lane = 0;


    }

    // Update is called once per frame
    void Update()
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
            if (jumpState == false)
            {
                jump();
            }

        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (lane > -2)
            {
                lane -= 2;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (lane < 2)
            {
                lane += 2;
            }
        }


        Vector3 newPosition = transform.position;
        newPosition.x = lane;
        transform.position = newPosition;
    }
    //on collision with fruit objects, play different sounds
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            PlaySound(0);
        }
        if (other.gameObject.CompareTag("Apple"))
        {
            PlaySound(2);
        }
        if (other.gameObject.CompareTag("Pear"))
        {
            PlaySound(2);
        }
        if (other.gameObject.CompareTag("Kiwi"))
        {
            PlaySound(2);
        }
    }
    //On jump, play jump sound and animation
    private void jump()
    {
        jumpState = true;
        PlaySound(1);
        anim.SetTrigger(jumpHash);
        transform.position = transform.position + new Vector3(0, 1.5f, 5);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        switch (hit.transform.tag)
        {

            case "Obstacle":
                death(hit);
                break;
            case "Coin":
                collectCoin(hit);
                break;
		case "Bush":
			death (hit);
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
         

    
    }
    //for playing selected audio clip
    void PlaySound(int clip)
    {
        AudioSource au = GetComponent<AudioSource>();
        au.clip = audioClip[clip];
        au.Play();
    }

    private void collectCoin(ControllerColliderHit hit)
    {
        
		scoreController.score = +10;
        Destroy(hit.gameObject);

    }


    public void loadByIndex(int sceneIndex)
    {

        SceneManager.LoadScene(sceneIndex);

    }

    public void strawberry()
    {
        
        //Double points per banana

    }
    public void apple(ControllerColliderHit hit)
    {
       
        Destroy(hit.gameObject);
		kiwiPowerup.powerOn = true;
		Debug.Log ("power on true from monkey move");
		scoreController.score =+20;
        //shield

    }
    public void kiwi()
    {
        //speed up
        speed += 5;
        timerState = true;
    }
    public void pear()
    {
        //more life 
        lives++;
    }
}