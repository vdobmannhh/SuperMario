using UnityEngine;

public abstract class Mushroom : QuestionBlockItem
{
    public float speed = 1.0f;

    float direction = 1.0f;
    float lastCol = 0;
    const float TIME_SINCE_LAST_COL = 0.1f;
  

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, speed * Time.deltaTime * direction);
    }

    private void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.CompareTag("Player"))
        {
            ChangeUi.scoreInc("Shroom");
            gameObject.SetActive(false);
            ItemSpecalizedBehavior();
        }
    }
    
    private void OnCollisionEnter(Collision obj)
    {
        var actualCol = Time.time;
        if (actualCol - lastCol > TIME_SINCE_LAST_COL &&
            !obj.gameObject.CompareTag("Ground") &&
            !obj.gameObject.CompareTag("Block"))
        {
            direction *= -1;
            transform.Rotate(new Vector3(0, 180, 0));
            lastCol = actualCol;
        }
    }
}
