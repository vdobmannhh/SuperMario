using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : QuestionBlockItem
{
    private float startTime;
    public float limit = 10;
    private RainbowColor rainbowColor;
    private FirstPersonController firstPersonController;
    // Start is called before the first frame update

    protected override void ItemSpecalizedBehavior()
    {
        rainbowColor.enabled = true;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        firstPersonController.star = true;
        Sounds.GetAudioSource(Sounds.AudioType.StarTheme).Play();
    }

    protected override void OnStart()
    {
        firstPersonController = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        rainbowColor = GameObject.FindGameObjectWithTag("Light").GetComponent<RainbowColor>();
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime >= limit)
        {
            firstPersonController.star = false;
            rainbowColor.enabled = false;
            gameObject.SetActive(false);
            Sounds.GetAudioSource(Sounds.AudioType.StarTheme).Stop();
        }
    }
}