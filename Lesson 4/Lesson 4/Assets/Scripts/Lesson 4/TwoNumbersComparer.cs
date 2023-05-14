using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TwoNumbersComparer : MonoBehaviour
{
    [SerializeField] private InputField _firstNumberField;
    [SerializeField] private InputField _secondNumberField;
    [SerializeField] private Text _rezultText;
    private string _firstNumber;
    private string _secondNumber;
    public void CompareTwoNumbers()
    {
        _firstNumber = _firstNumberField.text;
        _secondNumber = _secondNumberField.text;
        if (_firstNumber == null)
        {
            return;
        }
        if (_secondNumber == null)
        {
            return;
        }
        if (int.Parse(_firstNumber) > int.Parse(_secondNumber))
        {
            _rezultText.text = _firstNumber;
        }
        else
        {
            if (int.Parse(_firstNumber) < int.Parse(_secondNumber))
            {
                _rezultText.text = _secondNumber;
            }
            else _rezultText.text = "Равны";
        }
    }
       

}
