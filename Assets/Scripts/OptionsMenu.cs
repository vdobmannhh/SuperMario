using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class OptionsMenu : MonoBehaviour
{
    public GameObject mainMenu;
    [SerializeField] private TMP_Text volumeValueText = null;
    [SerializeField] private Toggle invincibleToggle = null;

    public GameObject gameStatistics;
    // Start is called before the first frame update
    void Start()
    {
        gameStatistics.SetActive(false);
        invincibleToggle.isOn = ConvertIntToBool(PlayerPrefs.GetInt("invincibleMode"));
        volumeValueText.text = PlayerPrefs.GetFloat("masterVolume").ToString("0.0");
        print(volumeValueText.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggleInvincibility()
    {
        invincibleToggle.isOn = !invincibleToggle.isOn;
    }

    public static bool ConvertIntToBool(int value)
    {
        bool val = true;
        if(value == 0)
        {
            val = false;
        }
        return val;
    }

    public static int ConvertBoolToInt(bool value)
    {
        int val = 0;
        if (value)
        {
            val = 1;
        }
        return val;
    }

    public void backtoMainMenu()
    {
        mainMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void RaiseVolume()
    {
        if (AudioListener.volume < 1.0f)
        {
            AudioListener.volume += 0.1f;
            volumeValueText.text = AudioListener.volume.ToString("0.0");
        }
    }

    public void DecreaseVolume()
    {
        if (AudioListener.volume > 0.0f)
        {
            AudioListener.volume -= 0.1f;
            volumeValueText.text = AudioListener.volume.ToString("0.0");
        }
    }
    public void ApplySettings()
    {
        PlayerPrefs.SetInt("invincibleMode", ConvertBoolToInt(invincibleToggle.isOn));
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        backtoMainMenu();
    }
}
