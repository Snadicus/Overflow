using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    // Variables

    // Speed of the coin when being deployed
    private float Speed = 10f; 

    // Rigidbody stuff
    private Rigidbody2D RB;

    bool stopMoving = false;
    int floorLayer = 6;
    float timer = 0f;
    float maxTimer = 1f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RandomCoinDirection();
    }

    void Update()
    {
        if(timer < maxTimer)
        {
            timer += Time.deltaTime;
        }
        else
        {
            stopMoving = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "End")
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if(!stopMoving)
            return;

        if(collision.gameObject.layer == floorLayer)
        {
            Destroy(RB);
            gameObject.layer = floorLayer;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
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
