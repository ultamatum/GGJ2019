using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryPrediction : MonoBehaviour
{
    public float timeBetweenDrops = 0.5f;
    public GameObject trajectoryPrefab;
    public GameObject TempObjectStorage;

    Vector2 curVel;
    Vector2 startPos;
    GameObject[] trajectoryDots = new GameObject[10];

    float dropTimer = 0;
    int dotsDropped;

    private void Start()
    {
        startPos = transform.position;

        for (int i = 0; i < trajectoryDots.Length; i++)
        {
            trajectoryDots[i] = Instantiate(trajectoryPrefab);
            trajectoryDots[i].transform.parent = TempObjectStorage.transform;
            trajectoryDots[i].SetActive(false);
        }
    }

    void Update()
    {
        if(this.gameObject.activeSelf)
        { 
            dropTimer += Time.deltaTime;

            if(dotsDropped >= trajectoryDots.Length)
            {
                ClearDots();
                transform.position = startPos;
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                GetComponent<Rigidbody2D>().AddForce(curVel);
                dotsDropped = 0;
            }

            if (dropTimer > timeBetweenDrops)
            {
                trajectoryDots[dotsDropped].transform.position = transform.position;
                trajectoryDots[dotsDropped].SetActive(true);

                dropTimer = 0;

                dotsDropped++;
            }
        }
    }

    public void ClearDots()
    {
        for(int i = 0; i < trajectoryDots.Length; i++)
        {
            trajectoryDots[i].SetActive(false);
        }
    }

    public void UpdateVel(Vector2 vel)
    {
        curVel = vel;
    }
}
