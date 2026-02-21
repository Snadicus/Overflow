using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    // Variables

    // Speed of the coin when being deployed
    private float Speed = 10f; 

    // Rigidbody stuff
    private Rigidbody2D RB;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RandomCoinDirection();
    }

    // Method for determining a random X and Y direction for the coins to fly out of the PC
    private void RandomCoinDirection()
    {
        // Get the Rigidbody component
        RB = GetComponent<Rigidbody2D>();

        // Generate a random direction vector with values between -1 and 1
        Vector2 RandomDirection = new Vector2(Random.Range(-1f, 1f), (Random.Range(0f, 1f)));

        // Normalize the vector to ensure consistent magnitude (length of 1)
        RandomDirection.Normalize();

        // Set the velocity based on the random direction and desired speed
        RB.linearVelocity = RandomDirection * Speed;
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
