using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MooveObstacle : MonoBehaviour
{
    [SerializeField]private Transform target;
    [SerializeField]private Transform startPosition;
    [SerializeField] private float power;
    private bool IsForward = false;
    void Start()
    {
        
    }

    void Update()
    {
        if (IsForward)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * power);
            if (Vector3.Distance(transform.position, target.position) < 0.5f)
            {
                IsForward = !IsForward;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition.position, Time.deltaTime * power);
            if (Vector3.Distance(transform.position, startPosition.position) < 0.5f)
            {
                IsForward = !IsForward;
            }
        }
    }
}
