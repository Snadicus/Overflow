using UnityEngine;

public class MovingHands : MonoBehaviour
{
    [SerializeField] Rigidbody2D handsRB;
    [SerializeField] MoneyCount moneyCount;
    [Space(20)]
    [SerializeField] float moveSpeed = 1;

    void Start()
    {
        handsRB.linearVelocity += Vector2.up * moveSpeed;
        moneyCount.OnZeroMoney += QuickRise;
    }

    void QuickRise() 
    {
        handsRB.linearVelocity += Vector2.up * 10f;
    }
}
