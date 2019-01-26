using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    Vector3 startpos;

    private void Start()
    {
        startpos = transform.position;
    }

    void LateUpdate()
    {
        if(Camera.main.WorldToScreenPoint(player.transform.position).x >= Screen.width / 2)
        {
            transform.position = new Vector3((player.transform.position.x), transform.position.y, transform.position.z);
        }
    }

    public void Reset()
    {
        transform.position = startpos;
    }
}
