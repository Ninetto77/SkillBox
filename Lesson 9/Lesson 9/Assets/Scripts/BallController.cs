using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float powerOfHit;
    private Rigidbody rb;
    [SerializeField] private float TimeToHit;
    private bool canMoove = true;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!canMoove)
            return;
        TimeToHit -= Time.deltaTime;
        if (TimeToHit < 0)
        {
            Hit();
            canMoove = false;
        }
    }
    private void Hit()
    {
        rb.AddForce(Vector3.back * powerOfHit, ForceMode.Impulse);
        Debug.Log("Hit");
    }
}
