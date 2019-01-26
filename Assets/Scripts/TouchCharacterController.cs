using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchCharacterController : MonoBehaviour
{
    public float forceScalar = 1;

    Vector2 startPos;
    Vector2 endPos;
    Vector2 dir;

    void Start()
    {
        
    }
    
    void Update()
    {
        if(Input.touches.Length > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startPos = touch.position;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                endPos = touch.position;

                dir = startPos - endPos;

                this.GetComponent<Rigidbody2D>().AddForce(dir * forceScalar);

                Debug.Log(dir);
            }
        }
    }
}
