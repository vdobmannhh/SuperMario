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
        ChangeUi.setMushroomDisplay(true);
        Destroy( gameObject );
    }
}