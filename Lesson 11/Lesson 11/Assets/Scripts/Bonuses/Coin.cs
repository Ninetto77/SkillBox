using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private ParticleSystem explosion;


    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            explosion.gameObject.SetActive(true);
            explosion.Play();
            Destroy(this.gameObject, 0.1f);

        }
    }
}
