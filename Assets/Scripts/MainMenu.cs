using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject gameStatistics;
    private FirstPersonController firstPersonController;

    private void Awake()
    {
        firstPersonController = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
    }

    private void Start()
    {
        gameStatistics.SetActive(false);
    }

    public void PlayGame()
    {
        ChangeUi.finished = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        if (firstPersonController != null)
        {
            firstPersonController.enabled = true;
        }

        gameStatistics.SetActive(true);
        PauseMenu.GameIsPaused = false;
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
