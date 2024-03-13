using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterCollideDedect : MonoBehaviour
{
    public int collectedStar = 0;
    public Animator chestAnimator;
    bool isAllStarCollected;
    public GameObject nextLevelButton;
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
            nextLevelButton.SetActive(true);
            Debug.Log("Level Completed");
        }
    }
    public void GoToNextLevel()
    {
        PlayerPrefs.SetInt("Level",PlayerPrefs.GetInt("Level")+1);
        SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));
    }
}
