using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMashine : MonoBehaviour
{
    [SerializeField] private GameObject _firstScreen;
    [SerializeField] private GameObject _secondScreen;
    private GameObject _currentScreen;
    void Start()
    {
        _firstScreen.SetActive(true);
        _secondScreen.SetActive(false);
        _currentScreen = _firstScreen;
    }

    public void ChangeStates(GameObject state)
    {
        if (_currentScreen == null)
        {
            return;
        }
        _currentScreen.SetActive(false);
        state.SetActive(true); 
        _currentScreen = state;
    }
}
