using UnityEngine;

public class CoinCreator : MonoBehaviour
{
    // Variables

    // Floats
    //private float PlayerXPosition;
    //private float PlayerYPosition;

    // GameObject Variables
    [SerializeField] MoneyThrowing moneyThrowing;
    [SerializeField] GameObject Coin; // For the coin prefab
    [Space(20)]
    [SerializeField] int coinsToSpawnAtOnce = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //LocatePlayer();
        moneyThrowing.OnThrowMoney += SpawnCoin;
    }
    
    /*
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
    */
    
    private void SpawnCoin()
    {
        // Records player location for testing
        //Debug.Log("X: " + transform.position.x + " --- Y = " + transform.position.y);

        // Gets exact player location so the coins can spawn in the right place
        //PlayerXPosition = PlayerObj.transform.position.x;
        //PlayerYPosition = PlayerObj.transform.position.y;

        for(int i = 0; i < coinsToSpawnAtOnce; ++i)
            Instantiate(Coin, moneyThrowing.gameObject.transform.position, Quaternion.identity);
    }

}
