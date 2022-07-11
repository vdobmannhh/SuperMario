using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutController : MonoBehaviour
{
    public Animator animator;

    public void FadeScreen(string name)
    {
        animator.SetTrigger("FadeOut");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
