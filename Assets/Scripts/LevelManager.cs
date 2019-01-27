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
    public GameObject optionButtons;
    public GameObject gemDisplay;
    public GameObject pausedUI;

    public GameObject[] gems = new GameObject[3];
    public GameObject[] completedGems = new GameObject[3];

    public bool levelComplete = false;
    public bool paused = false;

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
            player.GetComponent<Collider2D>().enabled = false;
            completedUI.SetActive(true);
            optionButtons.SetActive(false);
            gemDisplay.SetActive(false);
        }
    }

    public void RestartLevel()
    {
        collectableManager.GetComponent<CollectableManager>().Reset();
        player.GetComponent<TouchCharacterController>().ResetCharacter();
        mainCamera.GetComponent<CameraController>().Reset();

        completedUI.SetActive(false);
        optionButtons.SetActive(true);
        gemDisplay.SetActive(true);

        for (int i = 0; i < completedGems.Length; i++)
        {
            completedGems[i].SetActive(false);
        }
    }

    public void Pause()
    {
        paused = true;
        pausedUI.SetActive(true);
    }

    public void UnPause()
    {
        paused = false;
        pausedUI.SetActive(false);
    }

    public void QuitLevel()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
