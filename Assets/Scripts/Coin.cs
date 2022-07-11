using UnityEngine;

public class Coin : QuestionBlockItem
{
    public float force = 2.0f;
    const int COINS_TO_LEVEL_UP = 100;

    protected override void ItemSpecalizedBehavior()
    {
        if (ChangeUi.coin_count + 1 >= COINS_TO_LEVEL_UP)
        {
            GameObject.FindGameObjectWithTag("LifeUp").GetComponent<AudioSource>().Play();
            ChangeUi.life_count++;
            ChangeUi.coin_count = 0;
        }
        else
        {
            ChangeUi.coin_count++;
            GameObject.FindGameObjectWithTag("CoinSound").GetComponent<AudioSource>().Play();
        }
        ChangeUi.scoreInc("Coin");
        Destroy( gameObject );
    }

    protected override void OnStart()
    {
        GetComponent<Rigidbody>().AddForce(Random.insideUnitSphere.x * force, 0, Random.insideUnitSphere.z * force,
            ForceMode.Impulse);
    }
}