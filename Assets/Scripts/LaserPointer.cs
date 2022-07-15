using UnityEngine;
using Valve.VR.Extras;

public class LaserPointer : MonoBehaviour
{
    public SteamVR_LaserPointer laserPointer;
    public GameObject playerUICanvas;
    public GameObject optionsMenuUI;
    public GameObject mainMenuUI;
    public GameObject levelCompleteUI;
    private PauseMenu pauseMenu;
    private OptionsMenu optionsMenu;
    private MainMenu mainMenu;


    void Awake()
    {
        pauseMenu = playerUICanvas.GetComponent<PauseMenu>();
        optionsMenu = optionsMenuUI.GetComponent<OptionsMenu>();
        mainMenu = mainMenuUI.GetComponent<MainMenu>();
        laserPointer.PointerClick += PointerClick;
    }



    public void PointerClick(object sender, PointerEventArgs e)
    {
        Sounds.GetAudioSource(Sounds.AudioType.Click).Play();
        
        if (e.target.name == "ResumeButton")
        {
            pauseMenu.Resume();
        } else if (e.target.name == "MenuButton")
        {
            pauseMenu.LoadMenu();
        } else if (e.target.name == "QuitButton")
        {
            pauseMenu.QuitGame();
        } else if (e.target.name == "ToggleInvincible")
        {
            optionsMenu.toggleInvincibility();
        } else if (e.target.name == "plusVolume")
        {
            optionsMenu.RaiseVolume();
        } else if (e.target.name == "minusVolume")
        {
            optionsMenu.DecreaseVolume();
        } else if (e.target.name == "ApplyButton")
        {
            optionsMenu.ApplySettings();
        } else if (e.target.name == "BackButton")
        {
            optionsMenu.backtoMainMenu();
        } else if (e.target.name == "PlayButton")
        {
            mainMenu.PlayGame();
        } else if (e.target.name == "OptionsButton")
        {
            mainMenu.OpenOptionsMenu();
        } else if (e.target.name == "MainMenuQuitButton")
        {
            pauseMenu.QuitGame();
        } else if (e.target.name == "LevelCompleteNewGameButton")
        {
            mainMenu.PlayGame();
        } else if (e.target.name == "LevelCompleteMenuButton")
        {
            levelCompleteUI.SetActive(false);
            pauseMenu.LoadMenu();
        } else if (e.target.name == "LevelCompleteQuitButton")
        {
            pauseMenu.QuitGame();
        }
    }
}