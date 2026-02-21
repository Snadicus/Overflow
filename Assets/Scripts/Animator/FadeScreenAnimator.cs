using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class FadeScreenAnimator : MonoBehaviour
{
    [SerializeField] Animator animator;
    [Space(20)]
    [SerializeField] bool performFadeIn;
    [Tooltip("If unchecked, both event sets will be called, but the fade out animation won't play.")]
    [SerializeField] bool performFadeOut;
    [SerializeField] UnityEvent beforeFadeOut;
    [SerializeField] UnityEvent onFadeOut;

    void Start()
    {
        if(performFadeIn)
        {
            animator.SetTrigger("FadeIn");
        }
    }

    public void FadeOut()
    {
        beforeFadeOut?.Invoke();

        if(performFadeOut)
        {
            animator.Play("FadeOut");   
        }
        else
        {
            StartCoroutine(ReplaceFadeOutTime());
        }
    }

    public void AfterFadeOut()
    {
        onFadeOut?.Invoke();
    }

    IEnumerator ReplaceFadeOutTime()
    {
        yield return new WaitForSeconds(0.5f);
        AfterFadeOut();
    }
}
