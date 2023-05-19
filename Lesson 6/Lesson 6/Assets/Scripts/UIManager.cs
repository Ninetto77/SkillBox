using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _looseGameState;
    [SerializeField] private GameObject _winGameState;
    public void ChangeState(string gameState)
    {
        if (gameState == "Loose")
        {
            _looseGameState.SetActive(true);  
        }
        else if (gameState == "Win")
        {
            _winGameState.SetActive(true);
        }
    }

}
