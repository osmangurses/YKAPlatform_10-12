using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] GameObject characterCamera, mapCamera;

    public void ChangeCamera()
    {
        if (mapCamera.activeSelf)
        {
            mapCamera.SetActive(false);
            characterCamera.SetActive(true);

        }
        else
        {
            mapCamera.SetActive(true);
            characterCamera.SetActive(false);
        }
    }
}
