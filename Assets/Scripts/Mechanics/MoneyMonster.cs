using UnityEngine;

public class MoneyMonster : MonoBehaviour
{
    [SerializeField] MoneyCount moneyCount;
    [SerializeField] int moneyLayer = 8;
    [Space(20)]
    [SerializeField] int amountToConsume = 20;
    [SerializeField] UnityEngine.Events.UnityEvent OnConsumeMoney;

    bool hasEaten = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(hasEaten)
            return;
        
        if(collision.gameObject.layer == moneyLayer)
        {
            Destroy(collision.gameObject);
            moneyCount.SubtractMoneyBy(amountToConsume);
            hasEaten = true;
            OnConsumeMoney?.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasEaten)
            return;

        if (collision.gameObject.layer == moneyLayer)
        {
            Debug.Log("Hit");
            Destroy(collision.gameObject);
            moneyCount.SubtractMoneyBy(amountToConsume);
            hasEaten = true;
            OnConsumeMoney?.Invoke();
        }
    }
}
