using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private RelayRace[] players = new RelayRace[6];
    private void Start()
    {
        players[0].canMoove = true;
    }
    public void ChangePlayerState(int currentPlayer, int nextPlayer)
    {
        players[currentPlayer].canMoove = false;
        if (nextPlayer < 0)
            return;
        players[nextPlayer].canMoove = true;
    }
}
