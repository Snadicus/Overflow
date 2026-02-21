using UnityEngine;
using UnityEngine.Events;

public class FadeScreenAnimator : MonoBehaviour
{
    [SerializeField] Animator animator;
    [Space(20)]
    [SerializeField] UnityEvent OnFadeOut;

    public void FadeOut()
    {
        animator.Play("FadeOut");
    }

    public void AfterFadeOut()
    {
        OnFadeOut?.Invoke();
    }
}
