using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelayRace : MonoBehaviour
{
    [SerializeField]private Transform targetPosition;
    [SerializeField]private float speed;
    [SerializeField]private float passDistance;
    [SerializeField]private GameManager gameManager;
    [SerializeField]private int currentPlayer;
    [SerializeField]private int nextPlayer;
    public bool canMoove;
    void Start()
    {
        canMoove = false;
    }

    void Update()
    {
        if (canMoove)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, Time.deltaTime * speed);
            transform.LookAt(targetPosition.position);
            if ((targetPosition.position - transform.position).magnitude < passDistance)
            {
                gameManager.ChangePlayerState(currentPlayer, nextPlayer);
            }
        }
    }
}
