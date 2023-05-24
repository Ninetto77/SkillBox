using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Окно начала игры")]
    [Header("Текст")]
    [SerializeField] private Text TaskTxt;


    [Header("Окно игры")]
    [Header("Текст")]
    [SerializeField] private Text peasantCount;
    [SerializeField] private Text warriorCount;
    [SerializeField] private Text wheatCount;

    [SerializeField] private Text raidCountOfPeople;
    [SerializeField] private Text raidNextCountOfPeople;
    [SerializeField] private Text raidCycle;

    [SerializeField] private Text raidCurCycle;

    [Header("Кнопки")]
    [SerializeField] private Button peasantBtn;
    [SerializeField] private Button warriorBtn;

    [Header("Изображение")]
    [SerializeField] private Image raidTimerImg;
    [SerializeField] private Image peasantTimerImg;
    [SerializeField] private Image warriorTimerImg;
    
    [SerializeField] private Image soundImg;
    [SerializeField] private Sprite soundOffImg;
    [SerializeField] private Sprite soundOnImg;

    [Header("Окно паузы")]
    [Header("Текст")]
    [SerializeField] private Text peasantCountPause;
    [SerializeField] private Text wheatCountPause;
    [SerializeField] private Text warriorCountPause;
    [SerializeField] private Text warriorDeadCountPause;
    [SerializeField] private Text raidCyclePause;

    [Header("Окно проигрыша")]
    [Header("Текст")]
    [SerializeField] private Text peasantCountLoose;
    [SerializeField] private Text wheatCountLoose;
    [SerializeField] private Text wheatAllCountLoose;
    [SerializeField] private Text warriorAllCountLoose;
    [SerializeField] private Text warriorDeadCountLoose;
    [SerializeField] private Text raidCycleLoose;

    [Header("Окно выигрыша")]
    [Header("Текст")]
    [SerializeField] private Text peasantCountWin;
    [SerializeField] private Text wheatCountWin;
    [SerializeField] private Text wheatAllCountWin;
    [SerializeField] private Text warriorAllCountWin;
    [SerializeField] private Text warriorDeadCountWin;
    [SerializeField] private Text raidCycleWin;


    private GameManager gameManager;
    private AudioListener audioListener;

    private void Start()
    {
        gameManager = GetComponent<GameManager>();
        StartGame();
    }

    private void StartGame()
    {
        TaskTxt.text = "Соберите пшеницы: " + gameManager.GetWheatWinCount();
    }

    public void SetButtonInteractable(bool state, string s)
    {
        if (s == "Peasant")
        {
            peasantBtn.interactable = state;
        }

        if (s == "Warrior")
        {
            warriorBtn.interactable = state;
        }
    }

    public void FillAmountImage(float time, float maxTime, string s)
    {
        if (s == "Peasant")
        {
            peasantTimerImg.fillAmount = time / maxTime;
        }

        if (s == "Warrior")
        {
            warriorTimerImg.fillAmount = time / maxTime;
        }

        if (s == "Raid")
        {
            raidTimerImg.fillAmount = time / maxTime;
        }

        if (time  < 0)
        {
            peasantTimerImg.fillAmount = 1;
            raidTimerImg.fillAmount = 1;
            warriorTimerImg.fillAmount = 1;
        }
    }


    public void ChangeSoundSprite()
    {
        if (soundImg.sprite == soundOnImg)
        {
            soundImg.sprite = soundOffImg;
        }
        else
        {
            soundImg.sprite = soundOnImg;
        }
    }

    public void UpdateText(float pCount, float wCount, float whCount, float rCount, float rNextCount, float rCycle)
    {
        peasantCount.text = "Крестьян:" + pCount.ToString();
        warriorCount.text = "Воинов:" + wCount.ToString();
        wheatCount.text = "Пшеницы:" + whCount.ToString();

        raidCountOfPeople.text = "Врагов: " + rCount.ToString();
        raidNextCountOfPeople.text = "В следующем набеге: " + rNextCount.ToString();
        raidCycle.text = "Циклов до набега: " + rCycle.ToString();

        if (rCycle < 0)
        {
            raidCycle.text = "Берегись набегов!";
        }

        raidCurCycle.text = gameManager.GetCurrentCycle().ToString();
    }

    public void UpdatePauseText(float pCount, float whCount, float wAllCount, float wDeadCount, float rCycle)
    {
        peasantCountPause.text = "Крестьян: " + pCount.ToString();
        wheatCountPause.text = "Пшеницы: " + whCount.ToString();
        warriorCountPause.text = "Воинов всего: " + wAllCount.ToString();
        warriorDeadCountPause.text = "Падших воинов: " + wDeadCount.ToString();
        raidCyclePause.text = "Пройдено циклов: " + rCycle.ToString();
    }

    public void UpdateLooseText(float pCount, float whCount, float whAllCount, float wAllCount, float wDeadCount, float rCycle)
    {
        peasantCountLoose.text = "Крестьян: " + pCount.ToString();
        wheatCountLoose.text = "Пшеницы: " + whCount.ToString();
        wheatAllCountLoose.text = "Пшеницы всего: " + whAllCount.ToString();
        warriorAllCountLoose.text = "Воинов всего: " + wAllCount.ToString();
        warriorDeadCountLoose.text = "Падших воинов: " + wDeadCount.ToString();
        raidCycleLoose.text = "Пройдено циклов: " + rCycle.ToString();
    }

    public void UpdateWinText(float pCount, float whCount, float whAllCount, float wAllCount, float wDeadCount, float rCycle)
    {
        peasantCountWin.text = "Крестьян: " + pCount.ToString();
        wheatCountWin.text = "Пшеницы: " + whCount.ToString();
        wheatAllCountWin.text = "Пшеницы всего: " + whAllCount.ToString();
        warriorAllCountWin.text = "Воинов всего: " + wAllCount.ToString();
        warriorDeadCountWin.text = "Падших воинов: " + wDeadCount.ToString();
        raidCycleWin.text = "Пройдено циклов: " + rCycle.ToString();
    }
}
