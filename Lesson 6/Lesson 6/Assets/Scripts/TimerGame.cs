using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class TimerGame : MonoBehaviour
{
    [Header("UI элементы")]
    [SerializeField] private Text timerTxt;
    [SerializeField] private Text firstPinTxt;
    [SerializeField] private Text secondPinTxt;
    [SerializeField] private Text thirdPinTxt;

    [SerializeField] private UIManager _UIManager;

    [Header("Время")]
    [SerializeField] private float _startTimer;
    private float _deltaTime;
    private bool canWork = true;

    [Header("Начальные значения ключей")]
    [SerializeField]private float StartFirstKey;
    [SerializeField]private float StartSecondKey;
    [SerializeField]private float StartThirdKey;

    [Header("Итоговые значения ключей")]
    [SerializeField] private float finalFirstKey;
    [SerializeField] private float finalSecondKey;
    [SerializeField] private float finalThirdKey;

    [Header("Значения инструментов")]
    [SerializeField] private Vector3 drillKeysVector;
    [SerializeField] private Vector3 hammerKeysVector;
    [SerializeField] private Vector3 masterKeysVector;

    private float firstKey;
    private float secondKey;
    private float thirdKey;
    private float maxKey = 10;
    private float minKey =0;
    private Vector3 keysVector;    
    private Vector3 finalKeysVector;    

    void Start()
    {
        RestartGame();
    }

    void Update()
    {
        if (!canWork)
        {
            return;
        }

        _deltaTime -= Time.deltaTime;
        timerTxt.text = Math.Round(_deltaTime).ToString();
        RefreshPinText();

        if (_deltaTime < 0)
        {
            timerTxt.text = "0";
        }


        if (Math.Round(_deltaTime) == 0)
        {
            _UIManager.ChangeState("Loose");
            canWork= false;
        }

        if (keysVector == finalKeysVector)
        {
            _UIManager.ChangeState("Win");
            canWork = false;
        }
    }

    public void RestartGame()
    {
        canWork = true;
        timerTxt.text = _startTimer.ToString();
        _deltaTime = _startTimer;
        firstKey = StartFirstKey;
        secondKey = StartSecondKey;
        thirdKey = StartThirdKey;
        keysVector = new Vector3(firstKey, secondKey, thirdKey);
        finalKeysVector = new Vector3(finalFirstKey, finalSecondKey, finalThirdKey);
    }

    public void UseDrill()
    {
        Vector3 temp = keysVector + drillKeysVector;
        if ((temp[0] <= maxKey && temp[0] >= minKey) || (temp[1] <= maxKey && temp[1] >= minKey) || (temp[2] <= maxKey && temp[2] >= minKey))
        {
            keysVector = temp;
        }
    }

    public void UseHammer()
    {
        Vector3 temp = keysVector + hammerKeysVector;
        if ((temp[0] <= maxKey && temp[0] >= minKey) || (temp[1] <= maxKey && temp[1] >= minKey) || (temp[2] <= maxKey && temp[2] >=minKey))
        {
            keysVector = temp;
        }
    }

    public void UseMasterKey()
    {
        Vector3 temp = keysVector + masterKeysVector;
        if ((temp[0] <= maxKey && temp[0] >= minKey) || (temp[1] <= maxKey && temp[1] >= minKey) || (temp[2] <= maxKey && temp[2] >= minKey))
        {
            keysVector = temp;
        }
    }

    public void RefreshPinText()
    {
        firstPinTxt.text = keysVector[0].ToString();
        secondPinTxt.text = keysVector[1].ToString();
        thirdPinTxt.text = keysVector[2].ToString();
    }

}
