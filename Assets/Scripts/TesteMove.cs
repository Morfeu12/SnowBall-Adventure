using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesteMove : MonoBehaviour
{
    void Update() { MovePlayerRelativeToCamera(); }

    void MovePlayerRelativeToCamera() {
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
        Vector3 cameraRelativeMovement = forwardRelativeVerticalInput + rightRelativeVerticalInput;

        // Transform (Caracter humanoid) ou Rigidbody (Car, Ball...)
        // private Rigidbody rb = GetComponent<Rigidbody>();
        // rb.AddForce(cameraRelativeMovement * velocity * Time.deltaTime);
        transform.Translate(cameraRelativeMovement, Space.World);
    }
}
