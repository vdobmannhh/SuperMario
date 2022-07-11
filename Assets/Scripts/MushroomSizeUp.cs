using UnityEngine;
using UnityEngine.UI;

public class MushroomSizeUp : Mushroom
{
    protected override void OnStart()
    {
    }

    protected override void ItemSpecalizedBehavior()
    {
        player.GetComponent<FirstPersonController>().PowerUP("Mushroom");

        var shake = player.GetComponent<CameraShake>();
        shake.enabled = true;
        shake.shakeDuration = 1.0f;
        
        ChangeUi.setMushroomDisplay(true);
        gameObject.SetActive(false);
    }
}