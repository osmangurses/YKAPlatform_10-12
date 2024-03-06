using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollideDedect : MonoBehaviour
{
    public int collectedStar = 0;
    public Animator chestAnimator;
    bool isAllStarCollected;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            AudioManager.Instance.PlayFailSound();
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Star")
        {
            AudioManager.Instance.PlayCollectSound();
            Destroy(collision.gameObject);
            collectedStar++;
            if (collectedStar == 3)
            {
                isAllStarCollected = true;
                chestAnimator.SetBool("isChestOpen",true);
            }
        }
        else if (collision.gameObject.tag == "Chest" && isAllStarCollected)
        {
            AudioManager.Instance.PlayCompleteSound();
            Debug.Log("Level Completed");
        }
    }
}
