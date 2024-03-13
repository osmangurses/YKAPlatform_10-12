using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private void Start()
    {
       // PlayerPrefs.DeleteAll();
        if (!PlayerPrefs.HasKey("Level"))
        {
            PlayerPrefs.SetInt("Level",1);
        }
    }
    public void GoToGameplayScene()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));
    }
}
