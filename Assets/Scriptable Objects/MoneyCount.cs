using UnityEngine;

[CreateAssetMenu(fileName = "MoneyCount", menuName = "Scriptable Objects/MoneyCount")]
public class MoneyCount : ScriptableObject
{
    [SerializeField] int maxMoney = 500;
    int currentMoney = 500;

    public delegate void MoneyCountDelegate();
    public event MoneyCountDelegate OnChangeMoney;

    public void ResetMoneyCount()
    {
        currentMoney = maxMoney;
        OnChangeMoney?.Invoke();
    }

    public void SubtractMoneyBy(int amount)
    {
        currentMoney -= amount;
        OnChangeMoney?.Invoke();
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
