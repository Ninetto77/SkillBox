using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Superman : MonoBehaviour
{

    [SerializeField] private float powerOfHit;
    private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private float TimeToUp;
    private bool IsUp = true;
    private bool canMoove= false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (IsUp)
        {
            TimeToUp -= Time.deltaTime;
            if (0 < TimeToUp)
            {
                rb.velocity = Vector3.up * speed;

            }
            else
            {
                IsUp = false;
                TimeToUp = -1;
                rb.velocity = Vector3.zero;
                transform.rotation = Quaternion.Euler( 90,90, 0);
                canMoove = true;
            }
        }
        if (canMoove)
        {

            rb.velocity = Vector3.right * speed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody>() == null)
        {
            return;
        }

        if (collision.gameObject.layer == 7)
        {
            //Debug.Log("You are a good boy");
        }
        else
        {
            if (collision.gameObject.layer == 8)
            {
                //Debug.Log("You are a bad boy");
                Hit(collision.gameObject.transform);
            }
        }
    }

    private void Hit(Transform enemy)
    {
        Vector3 distance;

        distance = enemy.position-transform.position ;
        rb.AddForce(distance.normalized * powerOfHit, ForceMode.Impulse);
        //Debug.Log("Hit");

    }
}
