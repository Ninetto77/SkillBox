using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager _uIManager;


    public void PauseGame()
    {
        Time.timeScale = 0f;
        _uIManager.PauseMenu();
    }

    public void ReturnToGame()
    {
        Time.timeScale = 1f;
        _uIManager.GameMenu();
    }


}
