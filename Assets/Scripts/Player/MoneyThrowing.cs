using UnityEngine;

public class MoneyThrowing : MonoBehaviour
{
    [SerializeField] InputDetector inputDetector;
    [SerializeField] PlayerMovement playerMovement;
    [Space(20)]
    [Tooltip("Turn this option on if you don't want the player to be able to throw money while moving.")]
    [SerializeField] bool onlyThrowMoneyWhenStill = false;

    int moneyCount = 1000;

    public delegate void MoneyDelegate();
    public event MoneyDelegate OnThrowMoney;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputDetector.OnInteract += ThrowMoney;
        playerMovement.OnDoubleJump += ThrowMoney;
    }

    void ThrowMoney()
    {
        if(moneyCount == 0)
        {
            return;
        }

        if(onlyThrowMoneyWhenStill)
        {
            if(inputDetector.GetXVelocity() != 0)
            {
                return;
            }
        }

        Debug.Log("Money Thrown");
        OnThrowMoney?.Invoke();
    }
}
