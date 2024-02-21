using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    public Animator animator;

    public void PlayRunAnim()
    {
        animator.SetBool("IsRunning",true);
    }
    public void StopRunAnim()
    {
        animator.SetBool("IsRunning",false);
    }
    public void PlayJumpAnim()
    {
        animator.SetBool("IsJumping", true);
    }
    public void StopJumpAnim()
    {
        animator.SetBool("IsJumping", false);
    }
    
}
