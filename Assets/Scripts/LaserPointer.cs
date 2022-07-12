/* SceneHandler.cs*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using Valve.VR.Extras;

public class LaserPointer : MonoBehaviour
{
    public SteamVR_LaserPointer laserPointer;
    public GameObject playerUICanvas;
    public GameObject optionsMenuUI;
    public GameObject mainMenuUI;
    private PauseMenu pauseMenu;
    private OptionsMenu optionsMenu;
    private MainMenu mainMenu;
    private AudioSource clicksound;

    void Awake()
    {
        clicksound = GameObject.FindGameObjectWithTag("ClickSound").GetComponent<AudioSource>();
        pauseMenu = playerUICanvas.GetComponent<PauseMenu>();
        optionsMenu = optionsMenuUI.GetComponent<OptionsMenu>();
        mainMenu = mainMenuUI.GetComponent<MainMenu>();
        laserPointer.PointerClick += PointerClick;
    }



    public void PointerClick(object sender, PointerEventArgs e)
    {
        clicksound.Play();
        
        // switch (e.target.name)
        // {
        //     case "ResumeButton":
        //         pauseMenu.Resume();
        //         break;
        //     case "MenuButton":
        //         pauseMenu.LoadMenu();
        //         break;
        //     case "QuitButton":
        //         pauseMenu.QuitGame();
        //         break;
        //     case "ToggleInvincible":
        //         optionsMenu.toggleInvincibility();
        //         break;
        //     case "plusVolume":
        //         optionsMenu.RaiseVolume();
        //         break;
        //     case "minusVolume":
        //         optionsMenu.DecreaseVolume();
        //         break;
        //     case "ApplyButton":
        //         optionsMenu.ApplySettings();
        //         break;
        //     case "BackButton":
        //         optionsMenu.backtoMainMenu();
        //         break;
        //     case "PlayButton":
        //         mainMenu.PlayGame();
        //         break;
        //     case "OptionsButton":
        //         mainMenu.OpenOptionsMenu();
        //         break;
        //     case "MainMenuQuitButton":
        //         optionsMenu.backtoMainMenu();
        //         break;
        //     case "LevelCompleteNewGameButton":
        //         mainMenu.PlayGame();
        //         break;
        //     case "LevelCompleteMenuButton":
        //         optionsMenu.backtoMainMenu();
        //         break;
        //     case "LevelCompleteQuitButton":
        //         pauseMenu.QuitGame();
        //         break;
        // }
        if (e.target.name == "ResumeButton")
        {
            print("Resume");
            pauseMenu.Resume();
        } else if (e.target.name == "MenuButton")
        {
            print("menu");
            pauseMenu.LoadMenu();
        } else if (e.target.name == "QuitButton")
        {
            print("quit");
            pauseMenu.QuitGame();
        } else if (e.target.name == "ToggleInvincible")
        {
            print("toggle");
            optionsMenu.toggleInvincibility();
        } else if (e.target.name == "plusVolume")
        {
            print("plus");
            optionsMenu.RaiseVolume();
        } else if (e.target.name == "minusVolume")
        {
            print("minus");
            optionsMenu.DecreaseVolume();
        } else if (e.target.name == "ApplyButton")
        {
            print("apply");
            optionsMenu.ApplySettings();
        } else if (e.target.name == "BackButton")
        {
            print("back");
            optionsMenu.backtoMainMenu();
        } else if (e.target.name == "PlayButton")
        {
            print("play");
            mainMenu.PlayGame();
        } else if (e.target.name == "OptionsButton")
        {
            print("options");
            mainMenu.OpenOptionsMenu();
        } else if (e.target.name == "MainMenuQuitButton")
        {
            print("quit");
            optionsMenu.backtoMainMenu();
        } else if (e.target.name == "LevelCompleteNewGameButton")
        {
            print("newgame");
            mainMenu.PlayGame();
        } else if (e.target.name == "LevelCompleteMenuButton")
        {
            print("menu");
            optionsMenu.backtoMainMenu();
        } else if (e.target.name == "LevelCompleteQuitButton")
        {
            print("quit");
            pauseMenu.QuitGame();
        }
    }
}