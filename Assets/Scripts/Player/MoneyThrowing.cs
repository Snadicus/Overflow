using UnityEngine;

public class MoneyThrowing : MonoBehaviour
{
    [SerializeField] InputDetector inputDetector;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputDetector.OnInteract += ThrowMoney;
    }

    void ThrowMoney()
    {
        Debug.Log("Money Thrown");
    }
}
