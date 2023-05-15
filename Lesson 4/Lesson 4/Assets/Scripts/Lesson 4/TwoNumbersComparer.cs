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
        bool isAnyNumberNull = _secondNumber == null || _firstNumber == null;

        if (isAnyNumberNull)
        {
            return;
        }

        if (float.TryParse(_firstNumber, out float number1) && float.TryParse(_secondNumber, out float number2))
        {
            if (number1 > number2)
            {
                _rezultText.text = _firstNumber;
            }
            else
            {
                if (number1 < number2)
                {
                    _rezultText.text = _secondNumber;
                }
                else _rezultText.text = "Равны";
            }
        }
    }
       

}
