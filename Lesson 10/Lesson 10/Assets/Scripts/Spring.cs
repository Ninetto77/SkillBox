using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    [SerializeField] private float maxPower = 100;
    private Rigidbody body;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals(3))
        {
            body = other.gameObject.GetComponent<Rigidbody>();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (body != null)
        {
            body.AddForce(Vector3.right * maxPower, ForceMode.Impulse);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer.Equals(3))
        {
            body = null;
        }
        
    }
}
