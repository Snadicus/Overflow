using System.Collections;
using UnityEngine;

public class CrackedWalls : MonoBehaviour
{
    // Variables

    // Booleans
    private bool CanBeHit = true;

    // Events
    [SerializeField] private GameObject rockSprite;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip HitSounds;
    [SerializeField] private AudioClip DestroySounds;

    // Floats
    private float ShakeDuration = 0.5f;
    private float ShakeAmount = 0.1f;

    // Integers
    private int Health = 3; // Tracks how many times this wall has been hit with money

    // Vector2
    private Vector2 OriginalPosition;

    // Store the object's original position when the game starts
    void Start()
    {
        OriginalPosition = transform.localPosition;
    }

    // Damage Breakable Wall if Money touches it.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Money") && CanBeHit)
        {
            Debug.Log("Wall Damaged!");

            if (HitSounds != null)
            {
                audioSource.PlayOneShot(HitSounds);
            }

            TakeDamage(1);

            // Start shaking the Wall
            StartCoroutine(Shake());

            // Wait before allowing the player to hit it again
            StartCoroutine(HitCooldown(1.0f));
        }
    }

    // Destroy Wall once Health = 0
    public void TakeDamage(int DamageAmount)
    {
        Health -= DamageAmount;

        // Check if Health is zero or less
        if (Health <= 0)
        {
            Debug.Log("Wall Destroyed!");

            if (DestroySounds != null)
            {
                audioSource.PlayOneShot(DestroySounds);
            }

            Destroy(gameObject.GetComponent<BoxCollider2D>());
            rockSprite.SetActive(false);
        }
    }

    // Wall shakes a bit when collided into, then return to original positon
    IEnumerator Shake()
    {
        float Elapsed = 0.0f;

        while (Elapsed < ShakeDuration)
        {
            Vector2 RandomPoint = Random.insideUnitSphere * ShakeAmount;
            transform.localPosition = OriginalPosition + RandomPoint;
            Elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = OriginalPosition;
    }

    // Wait after player hits Wall with coins
    IEnumerator HitCooldown(float Delay)
    {
        CanBeHit = false;
        Debug.Log("Start Wait");

        yield return new WaitForSeconds(Delay);

        CanBeHit = true;
        Debug.Log("End Wait");
    }
}
