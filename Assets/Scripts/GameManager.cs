
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool GameOver;
    public float RestartDelay = 1f;
    public GameObject CompleteLevelUI;
    public GameObject LossLevelUI;
    

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CompleteLevel()
    {
        FindObjectOfType<CharAniController>().WonAni();
        FindObjectOfType<PlayerMovement>().dead = true;
        CompleteLevelUI.SetActive(true);
        FindObjectOfType<PlayerInventory>().FinalScore();


    }

    public void LoseLevel()
    {
        FindObjectOfType<CharAniController>().LostAni();
        FindObjectOfType<PlayerMovement>().dead = true;

        LossLevelUI.SetActive(true);
        FindObjectOfType<PlayerInventory>().FinalScore();
    }

}
