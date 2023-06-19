using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    private StateMashine stateMashine;

    private void Awake()
    {
        stateMashine = GetComponent<StateMashine>();
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

    public void LoudLevel(int level)
    {
        SceneManager.LoadScene(level);
        stateMashine.ChangeStates(StateMashine.StateType.game);
    }

}
