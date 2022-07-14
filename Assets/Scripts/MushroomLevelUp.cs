using UnityEngine;

public class MushroomLevelUp : Mushroom
{
    protected override void OnStart()
    {
    }
    
    protected override void ItemSpecalizedBehavior()
    {
        Sounds.GetAudioSource(Sounds.AudioType.OneUp).Play();
        ChangeUi.life_count++;
        Destroy( gameObject );
    }
}
