using System.Collections.Generic;
using UnityEngine;
using WildBall.Inputs;

[RequireComponent(typeof(PlayerMovement))]
public class InputManager : MonoBehaviour
{
    private PlayerMovement player;
    private Vector3 movement;
    private void Awake()
    {
        player = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
        float vertical = Input.GetAxis(GlobalStringVars.VERTICAL_AXIS);

        movement = new Vector3(horizontal, 0, vertical).normalized;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        player.MovePlayer(movement);
    }
}
