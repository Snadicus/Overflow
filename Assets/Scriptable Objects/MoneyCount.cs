using UnityEngine;

[CreateAssetMenu(fileName = "MoneyCount", menuName = "Scriptable Objects/MoneyCount")]
public class MoneyCount : ScriptableObject
{
    [SerializeField] int maxMoney = 500;
    [SerializeField] int currentMoney = 0;

    public delegate void MoneyCountDelegate();
    public event MoneyCountDelegate OnChangeMoney;
    public event MoneyCountDelegate OnZeroMoney;

    public void ResetMoneyCount()
    {
        currentMoney = maxMoney;
        OnChangeMoney?.Invoke();
    }

    public void SubtractMoneyBy(int amount)
    {
        currentMoney -= amount;
        OnChangeMoney?.Invoke();

        if(currentMoney <= 0)
            OnZeroMoney?.Invoke();
    }

    public int GetCurrentMoney()
    {
        return currentMoney;
    }

    public string GetCurrentMoneyString()
    {
        return "$" + currentMoney;
    }
}
