using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;
using Valve.VR.Extras;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;
    public GameObject mainMenuUI;
    public GameObject levelCompleteUI;
    public GameObject laserPointerHand;
    public GameObject tubeMenu;

    private GameObject player;

    private float lastSwitched;
    
    public GameObject shadowSphere;

    private SteamVR_LaserPointer laserPointerScript;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        laserPointerScript = laserPointerHand.GetComponent<SteamVR_LaserPointer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!levelCompleteUI.activeSelf && !mainMenuUI.activeSelf && !optionsMenuUI.activeSelf
            && Actions.GetMenuAction().GetStateUp(SteamVR_Input_Sources.Any))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        laserPointerScript.enabled = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        shadowSphere.SetActive(false);
    }

    public void Pause()
    {
        laserPointerScript.enabled = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        shadowSphere.SetActive(true);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        player.transform.position = new Vector3(tubeMenu.transform.position.x, tubeMenu.transform.position.y + 3,
            tubeMenu.transform.position.z);
        mainMenuUI.SetActive(true);
        shadowSphere.SetActive(false);
        pauseMenuUI.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}