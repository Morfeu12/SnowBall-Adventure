using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticulePoints : MonoBehaviour
{
    void Start(){Invoke("RemoveNode", 1.1f);}
    void RemoveNode(){Destroy(this.gameObject);}
}
