using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class moveball : MonoBehaviour
{
    [Header("Ball Settings")]
    private Rigidbody rb;
    public GameObject particule;
    public float velocity = 300;
    private int points = 0;
    public Text score;
    public Text Win;
    public GameObject author;
    public GameObject panel;

    [Header("Component Cronometer")]
    public Text timerText;
    private float currentTime;
    private int minute;
    private Text finalTime;

    [Header("Audio Crystals")]
    public AudioSource audioSource;
    public AudioClip clip;
    [Range(0.0f,1.0f)]
    public float volume = 0.4f;

    [Header("Stage Settings")]
    public int stagepoints = 15; // <-- 15 Default

    


    void Start()
    {  
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        score.text = "Score: " + points.ToString() + " / " + stagepoints.ToString();
        
    }

    void Update()
    {   
        if (points < stagepoints)
        {
            currentTime = currentTime += Time.deltaTime;

        }
        if(currentTime > 59)
        {
            currentTime = 0;
            minute++;
        }
        SetTimerText();
    }

    // FixedUpdate is called bettler performace em physical changes 
    void FixedUpdate()
    {
        // Vector3 position = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
        // rb.AddForce(position * velocity * Time.deltaTime);
        MovePlayerRelativeToCamera();
          
    }

    void LateUpdate() 
    {
       // PlaySoundBall();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("point")){
            Instantiate(particule, other.gameObject.transform.position, Quaternion.identity);
            audioSource.PlayOneShot(clip, volume);
            Destroy(other.gameObject);
            SetScore();
                        
        }
    
    }

    void SetScore()
    {
        points ++;
        score.text = "Score: " + points.ToString() + " / " + stagepoints.ToString();
        if (points >= stagepoints) 
        {
            // finalTime.text = timerText;
            Win.text = "YOU WIN!!!";
            author.SetActive(true);
            panel.SetActive(true);
        } 
    }

    private void SetTimerText()
    {
        timerText.text = minute.ToString("00") + ":" + currentTime.ToString("00"); 
    }
    
    private void MovePlayerRelativeToCamera() 
    {
        // Get Player Input (ORIGINAL INPUT SYSTEM)
        float playerVerticalInput = Input.GetAxis("Vertical");
        float playerHorizontalInput = Input.GetAxis("Horizontal");

        // Get Camera-Normalized Directional Vectors
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        forward.y = 0;
        right.y = 0;
        forward = forward.normalized;
        right = right.normalized;

        // Create Direction-Relative Input Vectors
        Vector3 forwardRelativeVerticalInput = playerVerticalInput * forward;
        Vector3 rightRelativeVerticalInput = playerHorizontalInput * right;

        // Create Camera-Relative Movement
        Vector3 cameraRelativeMovement =  forwardRelativeVerticalInput + rightRelativeVerticalInput;;
        rb.AddForce(cameraRelativeMovement * velocity * Time.deltaTime);        
    }

        /*
    private void PlaySoundBall () 
    {
        float ballMoving = Input.GetAxis("Vertical");

        if (ballMoving == 1 && !ballAudioController)
        {
            ballMovementAudio.PlayOneShot(clipBallMovement, volumeBallMovement);
            
        } 

        else if (ballMoving == -1) 
        {
            ballMovementAudio.PlayOneShot(clipBallMovement, volumeBallMovement);

        } else
        {
            ballMovementAudio.Pause();
        }



        
        if (Input.GetKeyDown("space"))
        {
            print("SOM");
        }

        if (Input.GetKeyUp("space"))
        {
            print("--Mute--");
        }


        if (Input.GetKeyUp("Up") || Input.GetKeyUp("W"))
        {
            print("QUIET");
        } 
    }
         */  


}

/*

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class moveball : MonoBehaviour
{
    [Header("Ball Settings")]
    private Rigidbody rb;
    public GameObject particule;
    public float velocity = 300;
    private int points = 0;
    public Text score;
    public Text Win;
    public GameObject author;

    [Header("Component Cronometer")]
    public Text timerText;
    private float currentTime;
    private int minute;
    private Text finalTime;

    void Start()
    {  
        rb = GetComponent<Rigidbody>();
        
    }

    void Update()
    {   
        if (points < 15)
        {
            currentTime = currentTime += Time.deltaTime;

        }
        if(currentTime > 59)
        {
            currentTime = 0;
            minute++;
        }
        SetTimerText();
    }

    // FixedUpdate is called bettler performace em physical changes 
    void FixedUpdate()
    {
        // Vector3 position = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
        // rb.AddForce(position * velocity * Time.deltaTime);
        MovePlayerRelativeToCamera();
          
    }
     void OnTriggerEnter(Collider other)
     {
        if(other.gameObject.CompareTag("point")){
            Instantiate(particule, other.gameObject.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            SetScore();
                        
        }
    
    }

    void SetScore()
    {
        points ++;
        score.text = "Score: " + points.ToString() + " / 15";
        if (points >= 15)
        {
            // finalTime.text = timerText;
            Win.text = "YOU WIN!!!";
            author.SetActive(true);
        } 
    }

    private void SetTimerText()
    {
        timerText.text = minute.ToString("00") + ":" + currentTime.ToString("00"); 
    }
    
    private void MovePlayerRelativeToCamera() 
    {
        // Get Player Input (ORIGINAL INPUT SYSTEM)
        float playerVerticalInput = Input.GetAxis("Vertical");
        float playerHorizontalInput = Input.GetAxis("Horizontal");

        // Get Camera-Normalized Directional Vectors
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        forward.y = 0;
        right.y = 0;
        forward = forward.normalized;
        right = right.normalized;

        // Create Direction-Relative Input Vectors
        Vector3 forwardRelativeVerticalInput = playerVerticalInput * forward;
        Vector3 rightRelativeVerticalInput = playerHorizontalInput * right;

        // Create Camera-Relative Movement
        Vector3 cameraRelativeMovement =  forwardRelativeVerticalInput + rightRelativeVerticalInput;;
        rb.AddForce(cameraRelativeMovement * velocity * Time.deltaTime);        
    }


}
*/
