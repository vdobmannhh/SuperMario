using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;
using Valve.VR.Extras;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;
    public GameObject mainMenuUI;
    public GameObject levelCompleteUI;
    public GameObject laserPointerHand;
    public GameObject spawnPoint;
    public GameObject cloud;

    private GameObject player;

    private float lastSwitched;
    
    public GameObject shadowSphere;

    private SteamVR_LaserPointer laserPointerScript;

    private Vector3 playerPosition;

    private GameObject tempCloud;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        laserPointerScript = laserPointerHand.GetComponent<SteamVR_LaserPointer>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Actions.GetSelectAction().GetStateUp(SteamVR_Input_Sources.Any))
        {
            print("clicked");
            // print(levelCompleteUI.activeSelf);
            // print(mainMenuUI.activeSelf);
            // print(optionsMenuUI.activeSelf);
        }
        
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
        // player.transform.position = playerPosition;
        // player.GetComponent<FirstPersonController>().enabled = true;
        // Destroy(tempCloud);
    }

    public void Pause()
    {
        // print(player.transform.position);
        // playerPosition = player.transform.position;
        // tempCloud = Instantiate(this.cloud, new Vector3(playerPosition.x, playerPosition.y + 20.0f, playerPosition.z - 5.0f),  Quaternion.identity);
        //
        // // player.GetComponent<FirstPersonController>().enabled = false;

        // player.transform.position =
        //     new Vector3(tempCloud.transform.position.x, tempCloud.transform.position.y + tempCloud.GetComponent<Collider>().bounds.extents.y,
        //         tempCloud.transform.position.z);
        //
        print(player.transform.position);

 
        
        laserPointerScript.enabled = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
      //  shadowSphere.SetActive(true);
        
        
    }

    public void LoadMenu()
    {
        print("Load Menu");
        
        Time.timeScale = 1f;
       player.transform.position = new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y + spawnPoint.GetComponent<Collider>().bounds.extents.y,
           spawnPoint.transform.position.z);

       player.GetComponent<FirstPersonController>().enabled = false;
        print(player.transform.position);
        
        mainMenuUI.SetActive(true);
        shadowSphere.SetActive(false);
        pauseMenuUI.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}