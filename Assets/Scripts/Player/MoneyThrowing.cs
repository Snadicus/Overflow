using UnityEngine;

public class MoneyThrowing : MonoBehaviour
{
    [SerializeField] InputDetector inputDetector;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] MoneyCount moneyCount;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] coinSounds;
    [Space(20)]
    [Tooltip("Turn this option on if you don't want the player to be able to throw money while moving.")]
    [SerializeField] bool onlyThrowMoneyWhenStill = false;
    [SerializeField] int amountPerThrow = 20;

    public delegate void MoneyThrowDelegate();
    public event MoneyThrowDelegate OnThrowMoney;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputDetector.OnInteract += ThrowMoney;
        playerMovement.OnDoubleJump += ThrowMoney;
    }

    void ThrowMoney()
    {
        if(moneyCount.GetCurrentMoney() <= 0)
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

        moneyCount.SubtractMoneyBy(amountPerThrow);
        audioSource.PlayOneShot(coinSounds[Random.Range(0, coinSounds.Length)]);
        OnThrowMoney?.Invoke();

        if(moneyCount.GetCurrentMoney() <= 0)
            moneyCount.ZeroMoney();
    }
}
