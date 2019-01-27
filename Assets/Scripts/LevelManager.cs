using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject collectableManager;
    public GameObject player;
    public GameObject mainCamera;
    public GameObject completedUI;

    public GameObject[] gems = new GameObject[3];
    public GameObject[] completedGems = new GameObject[3];

    public bool levelComplete = false;

    private void Update()
    {
        for (int i = 0; i < gems.Length; i++)
        {
            if(gems[i].activeSelf)
            {
                completedGems[i].SetActive(true);
            }
        }

        if(levelComplete == true)
        {
            completedUI.SetActive(true);
        }
    }

    public void RestartLevel()
    {
        collectableManager.GetComponent<CollectableManager>().Reset();
        player.GetComponent<TouchCharacterController>().ResetCharacter();
        mainCamera.GetComponent<CameraController>().Reset();

        for (int i = 0; i < completedGems.Length; i++)
        {
            completedGems[i].SetActive(false);
        }
    }

    public void QuitLevel()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
