using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StateMashine : MonoBehaviour
{
    [HideInInspector]
    public enum StateType
    {
        mainMenu,
        game,
        pauseGame,
        chooseLevel
    }

    [SerializeField] private GameObject _mainMenuScreen;
    [SerializeField] private GameObject _gameScreen;
    [SerializeField] private GameObject _pauseGameScreen;
    [SerializeField] private GameObject _chooseLevelScreen;
    private GameObject _currentScreen;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            _mainMenuScreen.SetActive(true);
            _gameScreen.SetActive(false);
            _pauseGameScreen.SetActive(false);
            _chooseLevelScreen.SetActive(false);

            _currentScreen = _mainMenuScreen;
        }
        else
        {
            _mainMenuScreen.SetActive(false);
            _gameScreen.SetActive(true);
            _pauseGameScreen.SetActive(false);
            _chooseLevelScreen.SetActive(false);

            _currentScreen = _gameScreen;
            Time.timeScale = 1f;
        }

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
            case StateType.mainMenu:
                _mainMenuScreen.SetActive(true);
                _currentScreen = _mainMenuScreen;
                break;
            case StateType.game:
                _gameScreen.SetActive(true);
                _currentScreen = _gameScreen;
                break;
            case StateType.pauseGame:
                _pauseGameScreen.SetActive(true);
                _currentScreen = _pauseGameScreen;
                break;
            case StateType.chooseLevel:
                _chooseLevelScreen.SetActive(true);
                _currentScreen = _chooseLevelScreen;
                break;
        }

    }
}
