using UnityEngine;
using UnityEngine.SceneManagement;

public class ScaleGoal : MonoBehaviour
{
    [SerializeField] GameObject emptyScale;
    [SerializeField] GameObject fullScale;
    [SerializeField] BoxCollider2D thisCollider;
    [SerializeField] FadeScreenAnimator fadeScreenAnimator;

    [SerializeField] float jumpSpeed = 1;

    GameObject player;

    void Start()
    {
        emptyScale.SetActive(true);
        fullScale.SetActive(false);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<MoneyThrowing>() != null)
        {
            player = collision.gameObject;
            player.GetComponent<MoneyThrowing>().OnThrowMoney += GoalReached;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(player != null)
        {
            player.GetComponent<MoneyThrowing>().OnThrowMoney -= GoalReached;
        }
    }

    void GoalReached()
    {
        player.GetComponent<MoneyThrowing>().OnThrowMoney -= GoalReached;
        emptyScale.SetActive(false);
        fullScale.SetActive(true);
        player.GetComponent<PlayerMovement>().ShootUpwards(jumpSpeed);
        fadeScreenAnimator.FadeOut();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
