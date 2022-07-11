using UnityEngine;

public abstract class QuestionBlockItem : MonoBehaviour
{
    protected GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        OnStart();
    }

    private void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.CompareTag("Player"))
        {
            ItemSpecalizedBehavior();
        }
    }

    protected abstract void OnStart();
    protected abstract void ItemSpecalizedBehavior();
}
