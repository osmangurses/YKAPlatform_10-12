using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CharacterMovement : MonoBehaviour
{
    public float charSpeed;
    public float jumpPower;
    public Vector3 rayPosition;
    public float rayLenght;
    public CharacterAnimationController characterAnimationController;
    public SpriteRenderer spriteRenderer;

    private int movementRotation;
    private bool isGrounded,isJumpSoundPlaying,isRunSoundPlaying;
    private void Start()
    {
        transform.position = new Vector2(PlayerPrefs.GetFloat("CharXPos"),PlayerPrefs.GetFloat("CharYPos"));
    }


    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + rayPosition, Vector2.down, rayLenght);
        Debug.DrawRay(transform.position + rayPosition, Vector3.down * rayLenght, Color.red);
        PlayerPrefs.SetFloat("CharXPos",transform.position.x);
        PlayerPrefs.SetFloat("CharYPos",transform.position.y);
        if (hit.collider != null && hit.collider.gameObject.tag == "Ground")
        {
            isGrounded = true;
            characterAnimationController.StopJumpAnim();
            isJumpSoundPlaying = false;
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
            SetMovementRotation(-1);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            SetMovementRotation(0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            SetMovementRotation(1);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            SetMovementRotation(0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpChar();
        }

    }
    public void SetMovementRotation(int movementrotation)
    {
        movementRotation = movementrotation;
        if (movementRotation!=0 && isGrounded)
        {
            AudioManager.Instance.PlayRunSound();
        }
        else
        {
            AudioManager.Instance.StopRunSound();
        }
    }
    public void JumpChar()
    {
        if (isGrounded)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPower); 
            
                AudioManager.Instance.PlayJumpSound();
                isJumpSoundPlaying = true;
            
        }
    }
}
