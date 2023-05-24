using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Управлением таймером")]
    [SerializeField] private ImageTimer harvestTimer;
    [SerializeField] private ImageTimer eatingTimer;

    [Header("Числовые данные")]
    [Header("Количество ")]
    [SerializeField] private float wheatWinCount;
    [SerializeField] private float peasantCount;
    [SerializeField] private float warriorCount;
    [SerializeField] private float wheatCount;

    [Header("Сбор пшеницы")]
    [SerializeField] private float wheatPerPeasant;
    [Header("Потребление пшеницы")]
    [SerializeField] private float wheatToWarrior;

    [Header("Стоимость")]
    [SerializeField] private float peasantCost;
    [SerializeField] private float warriorCost;

    [Header("Время")]
    [SerializeField] private float peasantCreateTime;
    [SerializeField] private float warriorCreateTime;

    [Header("Рейд")]
    [SerializeField] private float raidMaxTime;
    [SerializeField] private float noRaidMax;
    [SerializeField] private float raidIncrease;
    [SerializeField] private float raidCountOfPeople;

    private UIManager _uiManager;
    private StateMashine _stateMashine;
    private SoundManager _soundManager;

    private float peasantTime = 0;
    private float warriorTime = 0;
    private float raidTime = 0;

    private float peasantCurCount;
    private float warriorCurCount;
    private float wheatCurCount;
    private float raidCurCountOfPeople;
    private float raidCurCycle;

    private float wheatAllCount;
    private float warriorAllCount;
    private float warriorDeadCount;


    private bool isHiringPeasant;
    private bool isHiringWarrior;

    void Start()
    {
        _uiManager = GetComponent<UIManager>();
        _stateMashine = GetComponent<StateMashine>();
        _soundManager = GetComponent<SoundManager>();

        StartPlayGame();
    }


    void Update()
    {

        WaitForRaid();
        CheckForCorrect();

        if (harvestTimer.Tick == true)
        {
            CreateWheat();
            harvestTimer.Tick = false;
        }

        if (eatingTimer.Tick == true)
        {
            EatWheat();
            eatingTimer.Tick = false;
        }


        if (peasantTime > 0)
        {
            peasantTime -= Time.deltaTime;
            FillAmountImage(peasantTime, peasantCreateTime, "Peasant");
        }
        else if (peasantTime < 0)
        {
            CreatePeasant();
        }


        if (warriorTime > 0)
        {
            warriorTime -= Time.deltaTime;
            FillAmountImage(warriorTime, warriorCreateTime, "Warrior");
        }
        else if (warriorTime < 0)
        {
            CreateWarrior();
        }

        if (wheatWinCount < wheatCurCount)
        {
            WinGame();
            return;
        }

        if (warriorCurCount < 0)
        {
            LooseGame();
            return;
        }



        UpdateText();
    }



    private void CheckForCorrect()
    {
        CheckForWarriorCost();
        CheckForPeasantCost();
        CheckForCorrectWheatCount();
    }

    private void CheckForCorrectWheatCount()
    {
        if (wheatCurCount < 0)
        {
            wheatCurCount = 0;
        }
    }

    private void CheckForPeasantCost()
    {
        if (isHiringPeasant == false)
        {
            if (peasantCost > wheatCurCount)
            {
                _uiManager.SetButtonInteractable(false, "Peasant");
            }
            else _uiManager.SetButtonInteractable(true, "Peasant");
        }
    }

    private void CheckForWarriorCost()
    {
        if (isHiringWarrior == false)
        {
            if (warriorCost > wheatCurCount)
            {
                _uiManager.SetButtonInteractable(false, "Warrior");
            }
            else _uiManager.SetButtonInteractable(true, "Warrior");

        }
    }



    public void WaitForRaid()
    {
        raidTime -= Time.deltaTime;
        FillAmountImage(raidTime, raidMaxTime, "Raid");
        if (raidTime < 0)
        {
            raidTime = raidMaxTime;
            raidCurCycle++;

            if (raidCurCycle <= noRaidMax)
            {
                return;
            }

            if (warriorCurCount < raidCurCountOfPeople)
            {
                warriorDeadCount += warriorCurCount;
                warriorCurCount = -1;
            }
            else
            {
                warriorCurCount -= raidCurCountOfPeople;
                warriorDeadCount += raidCurCountOfPeople;
            }

            raidCurCountOfPeople += raidIncrease;
            _soundManager.PlayRaidSound();
        }
    }

    public void TryCreatePeasant()
    {
        peasantTime = peasantCreateTime;
        wheatCurCount -= peasantCost;
        isHiringPeasant = true;
        _uiManager.SetButtonInteractable(false, "Peasant");
    }

    public void TryCreateWarrior()
    {
        warriorTime = warriorCreateTime;
        wheatCurCount -= warriorCost;
        isHiringWarrior = true;
        _uiManager.SetButtonInteractable(false, "Warrior");
    }

    public void CreatePeasant()
    {
        peasantCurCount++;
        _uiManager.SetButtonInteractable(true, "Peasant");
        peasantTime = 0;

        _soundManager.PlayPeasantSound();
        isHiringPeasant = false;
    }

    public void CreateWarrior()
    {
        warriorCurCount++;
        warriorAllCount++;

        _uiManager.SetButtonInteractable(true, "Warrior");
        warriorTime = 0;

        _soundManager.PlayWarriorSound();
        isHiringWarrior = false;

    }

    public void CreateWheat()
    {
        wheatCurCount += wheatPerPeasant * peasantCurCount;
        wheatAllCount += wheatPerPeasant * peasantCurCount;

    }

    public void EatWheat()
    {
        wheatCurCount -= wheatToWarrior * warriorCurCount;
    }




    public void RestartGame()
    {
        Time.timeScale = 1f;
        _stateMashine.ChangeStates(StateMashine.StateType.game);

        raidTime = raidMaxTime;

        raidCurCycle = -1;
        peasantCurCount = peasantCount;
        warriorCurCount = warriorCount;
        wheatCurCount = wheatCount;
        raidCurCountOfPeople = 0;

        wheatAllCount = wheatCount;
        warriorAllCount = warriorCount;
        warriorDeadCount = 0;

        isHiringPeasant = false;
        isHiringWarrior = false;

        peasantTime = 0;
        warriorTime = 0;
        raidTime = 0;

    }
    private void StartPlayGame()
    {
        Time.timeScale = 0f;
        _stateMashine.ChangeStates(StateMashine.StateType.startGame);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        _stateMashine.ChangeStates(StateMashine.StateType.pauseGame);

        UpdatePauseText();
    }


    public void PlayGame()
    {
        Time.timeScale = 1f;
        _stateMashine.ChangeStates(StateMashine.StateType.game);
    }


    private void LooseGame()
    {
        Time.timeScale = 0f;
        _stateMashine.ChangeStates(StateMashine.StateType.looseGame);

        UpdateLooseText();
    }


    private void WinGame()
    {
        Time.timeScale = 0f;
        _stateMashine.ChangeStates(StateMashine.StateType.winGame);

        UpdateWinText();
    }


    private void UpdateText()
    {
        float raidNextCount = 0;
        if (raidCurCycle < noRaidMax)
        {
            raidNextCount = 0;
        }
        else
        {
            raidNextCount = raidCurCountOfPeople + raidIncrease;
        }
        _uiManager.UpdateText(peasantCurCount, warriorCurCount, wheatCurCount, raidCurCountOfPeople, raidNextCount, noRaidMax - raidCurCycle);
    }
    private void UpdatePauseText()
    {
        _uiManager.UpdatePauseText(peasantCurCount, wheatCurCount, warriorCurCount, warriorDeadCount, raidCurCycle);
    }

    private void UpdateWinText()
    {
        _uiManager.UpdateWinText(peasantCurCount, wheatCurCount, wheatAllCount, warriorAllCount, warriorDeadCount, raidCurCycle);

    }
    private void UpdateLooseText()
    {
        _uiManager.UpdateLooseText(peasantCurCount, wheatCurCount, wheatAllCount, warriorAllCount ,warriorDeadCount, raidCurCycle);
    }

    private void FillAmountImage(float time, float maxTime, string s)
    {
        _uiManager.FillAmountImage(time, maxTime, s);
    }
    public float GetCurrentCycle() => raidCurCycle;

    public float GetWheatWinCount() => wheatWinCount;
}
