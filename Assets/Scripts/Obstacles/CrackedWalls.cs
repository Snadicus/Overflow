using UnityEngine;

public class CrackedWalls : MonoBehaviour
{
    // Variables

    // Integers
    public int Health = 3; // Tracks how many times this wall has been hit with money
    
    // Damage Breakable Wall if Money touches it.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Money"))
        {
            Debug.Log("Wall Damaged!");
            TakeDamage(1);
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
            Destroy(gameObject);
        }
    }
}
