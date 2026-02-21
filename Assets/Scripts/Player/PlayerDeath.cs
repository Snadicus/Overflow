using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] InputDetector inputDetector;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip deathSound;
    [SerializeField] int dangerLayer = 7;
    [SerializeField] string level1SceneName = "JosephScene";
    [Space(20)]
    [SerializeField] UnityEvent OnDeath;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == dangerLayer)
        {
            Time.timeScale = 0;
            Debug.Log("You died.");
            inputDetector.OnRestart += RestartGame;
            audioSource.PlayOneShot(deathSound);
            OnDeath?.Invoke();
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(level1SceneName);
        Time.timeScale = 1;
    }
}
