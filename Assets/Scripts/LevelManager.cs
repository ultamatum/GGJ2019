using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject collectableManager;
    public GameObject player;
    public GameObject mainCamera;

    public void RestartLevel()
    {
        collectableManager.GetComponent<CollectableManager>().Reset();
        player.GetComponent<TouchCharacterController>().ResetCharacter();
        mainCamera.GetComponent<CameraController>().Reset();
    }
}
