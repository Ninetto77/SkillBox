using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject _showEnterKeyScreen;
    private StateMashine stateMashine;
    

    private void Awake()
    {
        stateMashine = GetComponent<StateMashine>();

        if (instance == null)
        {
            instance = this;
            return;
        }
        Destroy(this.gameObject);
    }
    public void PauseMenu()
    {
        stateMashine.ChangeStates(StateMashine.StateType.pauseGame);
    }
    public void MainMenu()
    {
        stateMashine.ChangeStates(StateMashine.StateType.mainMenu);
    }
    public void ChooseLevelMenu()
    {
        stateMashine.ChangeStates(StateMashine.StateType.chooseLevel);
    }
    public void GameMenu()
    {
        stateMashine.ChangeStates(StateMashine.StateType.game);
    }

    public void LooseGameMenu()
    {
        //ShowEnterKey(false);
        stateMashine.ChangeStates(StateMashine.StateType.looseGame);
    }

    public void WinGameMenu()
    {
        stateMashine.ChangeStates(StateMashine.StateType.winGame);
    }

    public void LoudLevel(int level)
    {
        SceneManager.LoadScene(level);
        stateMashine.ChangeStates(StateMashine.StateType.game);
    }

    internal void ShowEnterKey(bool state)
    {
        _showEnterKeyScreen.SetActive(state);
    }
}
