using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movecan : MonoBehaviour
{   
    public GameObject objectBall;
    private Vector3 startposition;
   
    void Start()
    {
        startposition = this.transform.position;
        
    }
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = objectBall.transform.position + startposition;
        
    }
}
