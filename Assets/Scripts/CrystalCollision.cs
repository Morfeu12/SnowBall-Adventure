using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalCollision : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 0.4f;
    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player")){
                          
        }
    }
}
