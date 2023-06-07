using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody body;
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        body.AddForce(Vector3.right * speed, ForceMode.Force);

        //transform.position = Vector3.MoveTowards(transform.position, Vector3.right, speed * Time.deltaTime);
    }
}
