using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float charSpeed;
    public float jumpPower;
    public Vector3 rayPosition;
    public float rayLenght;
    public CharacterAnimationController characterAnimationController;
    public SpriteRenderer spriteRenderer;

    private int movementRotation;
    private bool isGrounded;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Obstacle")
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + rayPosition, Vector2.down, rayLenght);
        Debug.DrawRay(transform.position + rayPosition, Vector3.down * rayLenght, Color.red);
        if (hit.collider != null && hit.collider.gameObject.tag == "Ground")
        {
            isGrounded = true;
            characterAnimationController.StopJumpAnim();
        }
        else
        {
            isGrounded = false;
            characterAnimationController.PlayJumpAnim();
        }
        if (movementRotation==0)
        {
            characterAnimationController.StopRunAnim();
        }
        else
        {
            characterAnimationController.PlayRunAnim();
        }
        if (movementRotation==-1)
        {
            spriteRenderer.flipX = true;
        }
        else if (movementRotation==1)
        {
            spriteRenderer.flipX = false;
        }
        transform.position += Vector3.right * charSpeed * movementRotation * Time.deltaTime;
        KeyboardControl();
    }
    void KeyboardControl()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            movementRotation = -1;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            movementRotation = 0;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            movementRotation = 1;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            movementRotation = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpChar();
        }

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
