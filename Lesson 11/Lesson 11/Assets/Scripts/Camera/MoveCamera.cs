using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    [SerializeField] private Transform player;
    private Vector3 offset;
    private void Start()
    {
        offset = transform.position - player.position;
    }
    void FixedUpdate()
    {
        transform.position = offset + player.position;
    }
}
