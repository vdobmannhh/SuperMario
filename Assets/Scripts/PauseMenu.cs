using UnityEngine;
using Valve.VR.Extras;
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
    private GameObject player;

    private float lastSwitched;

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
        if (!levelCompleteUI.activeSelf && !mainMenuUI.activeSelf && !optionsMenuUI.activeSelf
            && Actions.GetMenuAction())
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
    }

    public void Pause()
    {
        laserPointerScript.enabled = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        player.transform.position = new Vector3(spawnPoint.transform.position.x,
            spawnPoint.transform.position.y + spawnPoint.GetComponent<Collider>().bounds.extents.y,
            spawnPoint.transform.position.z);

        player.GetComponent<FirstPersonController>().enabled = false;

        mainMenuUI.SetActive(true);
        pauseMenuUI.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}