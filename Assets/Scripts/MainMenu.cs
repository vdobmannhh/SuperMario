using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject gameStatistics;

    private void Start()
    {
        gameStatistics.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameStatistics.SetActive(true);
        ChangeUi.resetUI();
        ChangeUi.life_count = 3;
        ChangeUi.coin_count = 0;
    }

   public void OpenOptionsMenu()
   {
       optionsMenu.SetActive(true);
       gameObject.SetActive(false);
   }
    public void QuitGame()
    {
        Application.Quit();
    }
}
