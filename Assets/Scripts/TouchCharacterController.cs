using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchCharacterController : MonoBehaviour
{
    public float forceScalar = 1;
    public GameObject trajectoryDotPrefab;
    public const float DOT_TIME_STEP = 0.005f;
    public const int NUM_DOTS_TO_SHOW = 20;

    GameObject[] trajectoryDots = new GameObject[NUM_DOTS_TO_SHOW];

    Vector2 startPos;
    Vector2 velocity;

    void Start()
    {
        for(int i = 0; i < trajectoryDots.Length; i++)
        {
            trajectoryDots[i] = Instantiate(trajectoryDotPrefab);
            trajectoryDots[i].transform.parent = this.gameObject.transform;
            trajectoryDots[i].AddComponent<Rigidbody2D>();
            trajectoryDots[i].SetActive(false);
        }
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

                DrawTrajectory();
            }

            if (touch.phase == TouchPhase.Ended)
            {                
                this.GetComponent<Rigidbody2D>().AddForce(velocity);

                for (int i = 0; i < trajectoryDots.Length; i++)
                {
                    trajectoryDots[i].SetActive(false);
                }

                Debug.Log(velocity);
            }
        }
    }

    void DrawTrajectory()
    {
        for (int i = 1; i < NUM_DOTS_TO_SHOW; i++)
        {
            GameObject trajectoryDot = trajectoryDots[i];
            trajectoryDots[i].SetActive(true);

            trajectoryDot.transform.position= CalcPos(DOT_TIME_STEP * i);
        }
    }

    private Vector2 CalcPos(float elapsedTime)
    {
        return (velocity * elapsedTime) + (Vector2)gameObject.transform.position;
    }
}
