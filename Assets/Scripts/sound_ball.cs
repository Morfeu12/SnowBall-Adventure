using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound_ball : MonoBehaviour
{
    
    [Header("Ball Movement Audio")]
    AudioSource audioSource;
    public AudioClip clipBall;
    [Range(0.0f,1.0f)]
    public float volumeBall = 0.1f;
    
    void Start() { audioSource = GetComponent<AudioSource>(); }

    void LateUpdate() { BallSounds(); }

    private void BallSounds() 
    {
        float ballMoving = Input.GetAxis("Vertical");
        //float impulse = ballMoving + impulse
        

       

        if (ballMoving == 1 && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(clipBall, volumeBall);

        } else if (ballMoving == 0 && audioSource.isPlaying)
        {
            audioSource.Pause();
        }
           
    }
}
