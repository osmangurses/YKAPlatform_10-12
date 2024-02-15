using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float charSpeed;
    public float jumpPower;
    public Vector3 rayPosition;
    public float rayLenght;

    private int movementRotation;
    private bool isGrounded;

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + rayPosition, Vector2.down, rayLenght);
        Debug.DrawRay(transform.position + rayPosition, Vector3.down * rayLenght, Color.red);

        if (hit.collider != null && hit.collider.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            movementRotation = -1;
        }
        
        if (Input.GetKeyUp(KeyCode.A))
        {
            movementRotation = 0;
        }


        transform.position += Vector3.right * charSpeed * movementRotation * Time.deltaTime;
        
    }
    public void SetMovementRotation(int movementrotation)
    {
        movementRotation = movementrotation;
    }
    public void JumpChar()
    {
        if (isGrounded)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPower);
        }
    }
}
