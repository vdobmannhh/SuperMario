using UnityEngine;

public class FadeOutController : MonoBehaviour
{
    public Animator animator;

    public void FadeScreen(string name)
    {
        animator.SetTrigger("FadeOut");
    }
}
