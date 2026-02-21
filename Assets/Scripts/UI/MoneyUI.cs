using UnityEngine;
using TMPro;

public class MoneyUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI counter;
    [SerializeField] MoneyCount moneyCount;
    [Space(20)]
    [SerializeField] bool resetMoneyCount;

    void Start()
    {
        if(resetMoneyCount)
            moneyCount.ResetMoneyCount();
        
        counter.text = moneyCount.GetCurrentMoneyString();
    }

    public void SubtractMoneyBy(int amount)
    {
        moneyCount.SubtractMoneyBy(amount);
        counter.text = moneyCount.GetCurrentMoneyString();
    }
}
