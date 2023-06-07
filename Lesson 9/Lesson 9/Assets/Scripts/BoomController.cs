using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomController : MonoBehaviour
{
    [SerializeField] private float TimeToExplosion;
    [SerializeField] private float powerOfExplosion;
    [SerializeField] private float radiusOfExplosion;
    void Start()
    {
        
    }

    void Update()
    {
        TimeToExplosion -= Time.deltaTime;
        if (TimeToExplosion < 0 )
        {
            Boom();
        }
    }

    private void Boom()
    {
        Rigidbody[] blocks = FindObjectsOfType<Rigidbody>();
        foreach( Rigidbody b in blocks )
        {
            float offset = Vector3.Distance(transform.position, b.position);
            if (offset < radiusOfExplosion )
            {
                Vector3 direction = b.position - transform.position;
                b.AddForce(direction.normalized * powerOfExplosion * (radiusOfExplosion - offset), ForceMode.Impulse);
            }
        }
        TimeToExplosion = 3;
    }
}
