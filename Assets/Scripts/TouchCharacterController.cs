using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchCharacterController : MonoBehaviour
{
    public float forceScalar = 1;
    public GameObject trajectoryObject;

    Vector2 startPos;
    Vector2 touchStartPos;
    Vector2 velocity;

    bool launched = false;

    void Start()
    {
        GetComponent<CircleCollider2D>().enabled = false;

        startPos = transform.position;
    }
    
    void Update()
    {
        if (!launched)
        {
            if (Input.touches.Length > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    touchStartPos = touch.position;

                    trajectoryObject.GetComponent<TrajectoryPrediction>().ResetDots();
                }

                if (touch.phase == TouchPhase.Moved)
                {
                    velocity = ((touchStartPos - touch.position) * forceScalar);

                    trajectoryObject.GetComponent<TrajectoryPrediction>().UpdateVel(velocity);
                    trajectoryObject.GetComponent<TrajectoryPrediction>().predict = true;
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    GetComponent<Rigidbody2D>().AddForce(velocity);

                    trajectoryObject.SetActive(false);
                    trajectoryObject.GetComponent<TrajectoryPrediction>().ClearDots();
                    GetComponent<CircleCollider2D>().enabled = true;

                    launched = true;
                }
            }
        }

        if(GetComponent<Rigidbody2D>().isKinematic == true)
        {
            GetComponent<Rigidbody2D>().isKinematic = false;
            launched = false;
            trajectoryObject.SetActive(true);
            GetComponent<CircleCollider2D>().enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {
            collision.gameObject.SetActive(false);
        }

        if(collision.gameObject.CompareTag("Goal"))
        {
            GameObject.FindGameObjectWithTag("Level Manager").GetComponent<LevelManager>().levelComplete = true;
        }
    }

    public void ResetCharacter()
    {
        velocity = Vector2.zero;
        launched = false;
        transform.position = startPos;
        transform.rotation = Quaternion.identity;
        trajectoryObject.GetComponent<TrajectoryPrediction>().ResetDots();
        this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        this.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        this.gameObject.GetComponent<TrailRenderer>().Clear();
    }
}
