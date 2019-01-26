using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    
    void LateUpdate()
    {
        Debug.Log(Camera.main.WorldToScreenPoint(player.transform.position).x);

        if(Camera.main.WorldToScreenPoint(player.transform.position).x >= Screen.width / 2)
        {
            transform.position = new Vector3((player.transform.position.x), transform.position.y, transform.position.z);
        }
    }
}
