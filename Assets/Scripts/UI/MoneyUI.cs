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
        moneyCount.OnChangeMoney += DisplayMoney;

        if(resetMoneyCount)
            moneyCount.ResetMoneyCount();

        DisplayMoney();
    }

    void DisplayMoney()
    {
        counter.text = moneyCount.GetCurrentMoneyString();
    }
}
