using UnityEngine;

public class CoinCreator : MonoBehaviour
{
    // Variables

    // Floats
    private float PlayerXPosition;
    private float PlayerYPosition;

    // GameObject Variables
    private GameObject PlayerObj = null; // For collecting player positon
    public GameObject Coin = null; // For the coin prefab

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LocatePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        SpawnCoin();
    }

    private void LocatePlayer()
    {
        // Refrences the Player for PlayerObj, to track location.
        if (PlayerObj == null)
        {
            PlayerObj = GameObject.Find("Player");
        }

        // Refrences the Coin prefab, to spawn it.
        if (Coin == null)
        {
            Coin = GameObject.Find("Coin");
        }
    }
    
    private void SpawnCoin()
    {
        // Records player location for testing
        Debug.Log("Player Position: X = " + PlayerObj.transform.position.x + " --- Y = " + PlayerObj.transform.position.y);

        // Gets exact player location so the coins can spawn in the right place
        PlayerXPosition = PlayerObj.transform.position.x;
        PlayerYPosition = PlayerObj.transform.position.y;

        Instantiate(Coin, new Vector2(PlayerXPosition, PlayerYPosition), Quaternion.identity);
    }

}
