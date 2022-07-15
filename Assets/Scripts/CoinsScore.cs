using TMPro;
using UnityEngine;

public class CoinsScore : MonoBehaviour
{
    public static int scoreValue = 0;
    TextMeshPro score;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        score.text = $"{scoreValue:00}";
    }
}
