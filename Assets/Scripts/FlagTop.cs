using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagTop : MonoBehaviour
{
    public static bool hitFlagTop = false;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.CompareTag("Player") || obj.gameObject.CompareTag("PlayerHead") || obj.gameObject.CompareTag("PlayerFeet"))
        {
            print("TOP");
            hitFlagTop = true;
        }
    }
}
