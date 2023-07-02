using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [Header("Позиции")]
    [SerializeField] private Transform player;
    [SerializeField] private Transform startPosition;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            return;
        }
        Destroy(this.gameObject);
    }

    public void ShowEnterKey(bool state)
    {
        UIManager.instance.ShowEnterKey(state);
    }

    public void ShowMainMenu()
    {
        Time.timeScale = 0f;
        UIManager.instance.MainMenu();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        UIManager.instance.PauseMenu();
    }

    public void ReturnToGame()
    {
        Time.timeScale = 1f;
        UIManager.instance.GameMenu();
    }

    public void RestartGame()
    {
        int index = (SceneManager.GetActiveScene().buildIndex) ;
        SceneManager.LoadScene(index);
    }

    public void LoadNextLevel()
    {
        int index = (SceneManager.GetActiveScene().buildIndex) + 1;
        SceneManager.LoadScene(index);
    }

    public void LooseGame()
    {
        player.gameObject.GetComponent<PlayerBehavior>().DeadPlayer();
        //Time.timeScale = 0f;
        //UIManager.instance.LooseGameMenu();
    }

    public void WinGame()
    {
        Time.timeScale = 0f;
        UIManager.instance.WinGameMenu();
    }

}
