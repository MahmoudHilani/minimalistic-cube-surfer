
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerInventory : MonoBehaviour
{

    public int CoinNum = 0;
    public int Multiplier = 1;
    public int HighScore = 0;
    public string HighScoreKey;
    public Text HighScoreText;
    public Text Score;
    public Text WinScore;
    public Text LossScore;
    
    

    private void Start()
    {
        HighScoreKey = SceneManager.GetActiveScene().name + "HighScore";
        HighScore = PlayerPrefs.GetInt(HighScoreKey);
    }
    private void Update()
    {
        Score.text = CoinNum.ToString("0");
        WinScore.text = CoinNum.ToString("0");
        HighScoreText.text = HighScore.ToString("0");
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
        if (CoinNum > HighScore)
        {
            HighScore = CoinNum;
            PlayerPrefs.SetInt(HighScoreKey, HighScore);
        }
    }
}
