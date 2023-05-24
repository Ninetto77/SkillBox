using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMashine : MonoBehaviour
{
    [HideInInspector]
    public enum StateType
    {
        startGame,
        game,
        looseGame,
        winGame,
        pauseGame
    }

    [SerializeField] private GameObject _startGameScreen;
    [SerializeField] private GameObject _gameScreen;
    [SerializeField] private GameObject _looseGameScreen;
    [SerializeField] private GameObject _winGameScreen;
    [SerializeField] private GameObject _pauseGameScreen;
    private GameObject _currentScreen;
    void Start()
    {
        _startGameScreen.SetActive(true);
        _gameScreen.SetActive(false);
        _looseGameScreen.SetActive(false);
        _winGameScreen.SetActive(false);
        _pauseGameScreen.SetActive(false);

        _currentScreen = _startGameScreen;
    }

    public void ChangeStates(StateType state)
    {
        if (_currentScreen == null)
        {
            return;
        }
        _currentScreen.SetActive(false);

        switch(state)
            {
            case StateType.startGame:
                _startGameScreen.SetActive(true);
                _currentScreen = _startGameScreen;
                break;
            case StateType.game:
                _gameScreen.SetActive(true);
                _currentScreen = _gameScreen;
                break;
            case StateType.looseGame:
                _looseGameScreen.SetActive(true);
                _currentScreen = _looseGameScreen;
                break;
            case StateType.winGame:
                _winGameScreen.SetActive(true);
                _currentScreen = _winGameScreen;
                break;
            case StateType.pauseGame:
                _pauseGameScreen.SetActive(true);
                _currentScreen = _pauseGameScreen;
                break;
        }

    }
}
