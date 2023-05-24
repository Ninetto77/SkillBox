using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("���� ������ ����")]
    [Header("�����")]
    [SerializeField] private Text TaskTxt;


    [Header("���� ����")]
    [Header("�����")]
    [SerializeField] private Text peasantCount;
    [SerializeField] private Text warriorCount;
    [SerializeField] private Text wheatCount;

    [SerializeField] private Text raidCountOfPeople;
    [SerializeField] private Text raidNextCountOfPeople;
    [SerializeField] private Text raidCycle;

    [SerializeField] private Text raidCurCycle;

    [Header("������")]
    [SerializeField] private Button peasantBtn;
    [SerializeField] private Button warriorBtn;

    [Header("�����������")]
    [SerializeField] private Image raidTimerImg;
    [SerializeField] private Image peasantTimerImg;
    [SerializeField] private Image warriorTimerImg;
    
    [SerializeField] private Image soundImg;
    [SerializeField] private Sprite soundOffImg;
    [SerializeField] private Sprite soundOnImg;

    [Header("���� �����")]
    [Header("�����")]
    [SerializeField] private Text peasantCountPause;
    [SerializeField] private Text wheatCountPause;
    [SerializeField] private Text warriorCountPause;
    [SerializeField] private Text warriorDeadCountPause;
    [SerializeField] private Text raidCyclePause;

    [Header("���� ���������")]
    [Header("�����")]
    [SerializeField] private Text peasantCountLoose;
    [SerializeField] private Text wheatCountLoose;
    [SerializeField] private Text wheatAllCountLoose;
    [SerializeField] private Text warriorAllCountLoose;
    [SerializeField] private Text warriorDeadCountLoose;
    [SerializeField] private Text raidCycleLoose;

    [Header("���� ��������")]
    [Header("�����")]
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
        TaskTxt.text = "�������� �������: " + gameManager.GetWheatWinCount();
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
        peasantCount.text = "��������:" + pCount.ToString();
        warriorCount.text = "������:" + wCount.ToString();
        wheatCount.text = "�������:" + whCount.ToString();

        raidCountOfPeople.text = "������: " + rCount.ToString();
        raidNextCountOfPeople.text = "� ��������� ������: " + rNextCount.ToString();
        raidCycle.text = "������ �� ������: " + rCycle.ToString();

        if (rCycle < 0)
        {
            raidCycle.text = "�������� �������!";
        }

        raidCurCycle.text = gameManager.GetCurrentCycle().ToString();
    }

    public void UpdatePauseText(float pCount, float whCount, float wAllCount, float wDeadCount, float rCycle)
    {
        peasantCountPause.text = "��������: " + pCount.ToString();
        wheatCountPause.text = "�������: " + whCount.ToString();
        warriorCountPause.text = "������ �����: " + wAllCount.ToString();
        warriorDeadCountPause.text = "������ ������: " + wDeadCount.ToString();
        raidCyclePause.text = "�������� ������: " + rCycle.ToString();
    }

    public void UpdateLooseText(float pCount, float whCount, float whAllCount, float wAllCount, float wDeadCount, float rCycle)
    {
        peasantCountLoose.text = "��������: " + pCount.ToString();
        wheatCountLoose.text = "�������: " + whCount.ToString();
        wheatAllCountLoose.text = "������� �����: " + whAllCount.ToString();
        warriorAllCountLoose.text = "������ �����: " + wAllCount.ToString();
        warriorDeadCountLoose.text = "������ ������: " + wDeadCount.ToString();
        raidCycleLoose.text = "�������� ������: " + rCycle.ToString();
    }

    public void UpdateWinText(float pCount, float whCount, float whAllCount, float wAllCount, float wDeadCount, float rCycle)
    {
        peasantCountWin.text = "��������: " + pCount.ToString();
        wheatCountWin.text = "�������: " + whCount.ToString();
        wheatAllCountWin.text = "������� �����: " + whAllCount.ToString();
        warriorAllCountWin.text = "������ �����: " + wAllCount.ToString();
        warriorDeadCountWin.text = "������ ������: " + wDeadCount.ToString();
        raidCycleWin.text = "�������� ������: " + rCycle.ToString();
    }
}
