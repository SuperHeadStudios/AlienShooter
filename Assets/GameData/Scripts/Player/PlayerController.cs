using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private pAnimatorController controler;
    

    private void FixedUpdate()
    {
        MoveControl();
    }

    private void MoveControl()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
                
        Vector3 direction = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;
        if (direction.magnitude > 0.001f)
        {
            characterController.Move(direction * moveSpeed * Time.smoothDeltaTime);
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.smoothDeltaTime);
            controler.IsRun();
        }
        else
        {
            controler.Isidle();
        }
        
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
}
