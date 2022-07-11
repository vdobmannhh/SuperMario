using UnityEngine;

public class MushroomLevelUp : Mushroom
{
    protected override void OnStart()
    {
    }
    
    protected override void ItemSpecalizedBehavior()
    {
        GameObject.FindGameObjectWithTag("LifeUp").GetComponent<AudioSource>().Play();
        ChangeUi.life_count++;
        Destroy( gameObject );
    }
}
