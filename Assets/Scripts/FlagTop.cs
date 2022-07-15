using UnityEngine;

public class FlagTop : MonoBehaviour
{
    private void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.CompareTag("Player") || obj.gameObject.CompareTag("PlayerHead") || obj.gameObject.CompareTag("PlayerFeet"))
        {
            ChangeUi.scoreInc("Top");
        }
    }
}
