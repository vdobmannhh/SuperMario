using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : QuestionBlockItem
{
    private float startTime;
    public float limit = 10;
    private RainbowColor rainbowColor;
    private FirstPersonController player;
    // Start is called before the first frame update

    protected override void ItemSpecalizedBehavior()
    {
        rainbowColor.enabled = true;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        player.star = true;
    }

    protected override void OnStart()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        rainbowColor = GameObject.FindGameObjectWithTag("Light").GetComponent<RainbowColor>();
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime >= limit)
        {
            player.star = false;
            rainbowColor.enabled = false;
            gameObject.SetActive(false);
        }
    }
}