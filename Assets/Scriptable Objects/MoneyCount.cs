using UnityEngine;

[CreateAssetMenu(fileName = "MoneyCount", menuName = "Scriptable Objects/MoneyCount")]
public class MoneyCount : ScriptableObject
{
    [SerializeField] int maxMoney = 500;
    int currentMoney = 500;

    public void ResetMoneyCount()
    {
        currentMoney = maxMoney;
    }

    public void SubtractMoneyBy(int amount)
    {
        currentMoney -= amount;
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
