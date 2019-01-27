using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public void LoadLevelByID(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void LoadLevelByName(string level)
    {
        SceneManager.LoadScene(level);
    }
}
