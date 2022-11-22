
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public int CoinNum = 0;
    public int Multiplier = 1;
    public Text Score;
    public Text WinScore;
    public Text LossScore;
    
    

    private void Update()
    {
        Score.text = CoinNum.ToString("0");
        WinScore.text = CoinNum.ToString("0");
        LossScore.text = CoinNum.ToString("0");
    }
    public void CoinCollected()
    {
        CoinNum += 1;
    }

    public void AddMultiplier()
    {
        Multiplier++;
    }

    public void FinalScore()
    {
        CoinNum = CoinNum * Multiplier;
    }
}
