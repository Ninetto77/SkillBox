using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calculator : MonoBehaviour
{
    [SerializeField] private InputField _firstNumberField;
    [SerializeField] private InputField _secondNumberField;
    [SerializeField] private Text _rezultText;
    private string _firstNumber;
    private string _secondNumber;
    private string _rezult;

    public void CalculateSumRezult()
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
        _rezult = (int.Parse(_firstNumber) + int.Parse(_secondNumber)).ToString();
        _rezultText.text = _rezult;
    }

    public void CalculateMinusRezult()
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
        _rezult = (int.Parse(_firstNumber) - int.Parse(_secondNumber)).ToString();
        _rezultText.text = _rezult;
    }

    public void CalculateMultiplicateRezult()
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
        _rezult = (int.Parse(_firstNumber) * int.Parse(_secondNumber)).ToString();
        _rezultText.text = _rezult;
    }

    public void CalculateDivRezult()
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
        _rezult = (int.Parse(_firstNumber) / int.Parse(_secondNumber)).ToString();
        _rezultText.text = _rezult;
    }
}
