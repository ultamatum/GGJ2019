using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchCharacterController : MonoBehaviour
{
    public float forceScalar = 1;
    public GameObject ballObject;
    
    Vector2 startPos;
    Vector2 velocity;

    void Start()
    {
        GetComponent<CircleCollider2D>().enabled = false;
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

            if(touch.phase == TouchPhase.Moved)
            {
                velocity = ((startPos - touch.position) * forceScalar);

                ballObject.GetComponent<TrajectoryPrediction>().UpdateVel(velocity);
            }

            if (touch.phase == TouchPhase.Ended)
            {                
                this.GetComponent<Rigidbody2D>().AddForce(velocity);

                ballObject.SetActive(false);
                ballObject.GetComponent<TrajectoryPrediction>().ClearDots();
                GetComponent<CircleCollider2D>().enabled = true;
            }
        }
    }
}
