using UnityEngine;

public class FloatingCoin : MonoBehaviour
{
    const int COINS_TO_LEVEL_UP = 100;

    public float maxRotation = 1f;
    public float minRotation = 0.5f;

    private float rotationSpeed;
    private int COINT_COUNT = 10;

    private void Start()
    {
        rotationSpeed = Random.Range(minRotation,maxRotation);
    }

    private void Update()
    {
        transform.Rotate(0, rotationSpeed, 0);
    }

    private void OnTriggerEnter(Collider obj)
    {
        
        if (obj.gameObject.CompareTag("Player"))
        {
            if (ChangeUi.coin_count + COINT_COUNT >= COINS_TO_LEVEL_UP)
            {
                GameObject.FindGameObjectWithTag("LifeUp").GetComponent<AudioSource>().Play();
                ChangeUi.life_count++;
                ChangeUi.coin_count = (ChangeUi.coin_count + COINT_COUNT) % COINS_TO_LEVEL_UP;
            }
            else
            {
                ChangeUi.coin_count += COINT_COUNT;
                GameObject.FindGameObjectWithTag("CoinSound").GetComponent<AudioSource>().Play();
            }   
            gameObject.SetActive(false);
        }
    }
}
