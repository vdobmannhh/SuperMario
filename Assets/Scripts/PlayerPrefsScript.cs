using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsScript : MonoBehaviour
{
    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
