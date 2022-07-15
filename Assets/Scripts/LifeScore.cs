using TMPro;
using UnityEngine;

public class LifeScore : MonoBehaviour
{
    public static int scoreValue = 0;
    TMPro.TextMeshProUGUI score;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
       score.text = "x"+ scoreValue;   
    }
}
