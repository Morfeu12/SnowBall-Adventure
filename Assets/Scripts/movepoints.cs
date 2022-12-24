using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movepoints : MonoBehaviour
{
  
    void Update()
    {
        transform.Rotate(new Vector3(15,30,45) * Time.deltaTime);
       // transform.scale(new Vector3(0.01f,0.01f,0.01f) * Time.deltaTime);
    }
}
