using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableManager : MonoBehaviour
{
    public GameObject[] collectables = new GameObject[3];

    public void Reset()
    {
        for(int i = 0; i < collectables.Length; i++)
        {
            collectables[i].gameObject.SetActive(true);
        }
    }
}
