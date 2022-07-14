using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagTop : MonoBehaviour
{
    // Update is called once per frame
    private void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.CompareTag("Player") || obj.gameObject.CompareTag("PlayerHead") || obj.gameObject.CompareTag("PlayerFeet"))
        {
            ChangeUi.scoreInc("Top");
        }
    }
}
