using UnityEngine;

public class EndingTally : MonoBehaviour
{
    [SerializeField] MoneyCount moneyCount;
    [SerializeField] TMPro.TextMeshProUGUI moneyDisplay;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip coinSound;
    [SerializeField] UnityEngine.Playables.PlayableDirector badEnding;
    [SerializeField] UnityEngine.Playables.PlayableDirector goodEnding;

    public void TallyMoney()
    {
        StartCoroutine(TallyMoneyOverTime());
    }

    void DetermineEnding()
    {
        if(moneyCount.GetCurrentMoney() > 0)
        {
            badEnding.Play();
        }
        else
        {
            goodEnding.Play();
        }
    }

    System.Collections.IEnumerator TallyMoneyOverTime()
    {
        int money = moneyCount.GetCurrentMoney();

        for(int i = 0; i <= money; ++i)
        {
            moneyDisplay.text = "$" + i;
            audioSource.PlayOneShot(coinSound);
            yield return null;
        }

        DetermineEnding();
    }
}
