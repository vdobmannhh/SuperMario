using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
