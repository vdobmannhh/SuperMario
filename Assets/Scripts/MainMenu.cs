using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject gameStatistics;
    private FirstPersonController firstPersonController;

    private void Start()
    {
        gameStatistics.SetActive(false);
        firstPersonController = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
    }

    public void PlayGame()
    {
        print("playGame");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        firstPersonController.enabled = true;
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
