using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moovement : MonoBehaviour
{
    public float speed;

    private Vector3[] positions = new Vector3[4];
    private Vector3 firstPosition;
    private Vector3 secondPosition;
    private Vector3 thirdPosition;
    private Vector3 forthPosition;

    private bool forward;
    private int i;

    void Start()
    {
        firstPosition = new Vector3(0, 0, 0);
        secondPosition = new Vector3(0, 5, 0);
        thirdPosition = new Vector3(0, 5, 5);
        forthPosition = new Vector3(0, 0, 5);

        positions[0] = firstPosition;
        positions[1] = secondPosition;
        positions[2] = thirdPosition;
        positions[3] = forthPosition;

        forward = true;
        i = 0;
    }

    void Update()
    {
        if (forward)
        {
            if (i == 3)
            {
                forward = !forward;
            }

            transform.position = Vector3.MoveTowards(transform.position, positions[i], Time.deltaTime * speed);
            if (transform.position == positions[i])
            {
                i++;
            }


        }

        if (!forward)
        {

            transform.position = Vector3.MoveTowards(transform.position, positions[i], Time.deltaTime * speed);
            if (transform.position == positions[i])
            {
                i--;
            }

            if (i == 0)
            {
                forward = !forward;
            }

        }
    }
}
