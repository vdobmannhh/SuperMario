using UnityEngine;

public class PlayerPrefsScript : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this);
        if (!PlayerPrefs.HasKey("masterVolume"))
        {
            UnityEngine.PlayerPrefs.SetFloat("masterVolume", 0.5f);
        }
        if (!PlayerPrefs.HasKey("invincibleMode"))
        {
            UnityEngine.PlayerPrefs.SetInt("invincibleMode", OptionsMenu.ConvertBoolToInt(false));
        }
    }
}
