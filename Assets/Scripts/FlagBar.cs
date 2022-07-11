using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlagBar : MonoBehaviour
{
    public float animationSpeed = 2.0f;
    public GameObject LevelCompleteUI;
    
    private bool isPlayerOnBar = false;
    private bool playerAnimation = false;
    
    private GameObject player;
    private GameObject playerFeet;
    private FirstPersonController playerFirstPersonController;
    private CapsuleCollider playerCollider;
    private SphereCollider playerFeetCollider;
    
    private BoxCollider boxCollider;

   

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerFeet = GameObject.FindGameObjectWithTag("PlayerFeet");
        playerFeetCollider = playerFeet.GetComponent<SphereCollider>();
        playerCollider = player.GetComponent<CapsuleCollider>();
        playerFirstPersonController = player.GetComponent<FirstPersonController>();
        
        boxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerOnBar && !playerAnimation)
        {
            playerAnimation = true;
            playerFirstPersonController.enabled = false;
            playerCollider.enabled = false;
            playerFeetCollider.enabled = false;
            GameObject.FindGameObjectWithTag("MainTheme").GetComponent<AudioSource>().Stop();
            GameObject.FindGameObjectWithTag("FlagpoleSound").GetComponent<AudioSource>().Play();
        }

        if (playerAnimation)
        {
            player.transform.position -= new Vector3(0, Time.deltaTime * animationSpeed, 0);
            if (playerFeetCollider.bounds.center.y <= boxCollider.bounds.center.y - boxCollider.bounds.extents.y + 0.05)
            {
                playerAnimation = false;
                playerCollider.enabled = true;
                playerFeetCollider.enabled = true;
                isPlayerOnBar = false;
                ChangeUi.scoreInc("Time");
                ChangeUi.scoreInc("Flag");
                LevelCompleteUI.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider obj)
    {
        if ((obj.gameObject.CompareTag("Player") || obj.gameObject.CompareTag("PlayerHead")) && !obj.gameObject.CompareTag("PlayerFeet"))
        {
            isPlayerOnBar = true;
        }
    }
}