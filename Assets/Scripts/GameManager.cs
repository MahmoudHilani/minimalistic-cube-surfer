
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

    private void Start()
    {
        GameObject.FindGameObjectWithTag("PlayerCube").GetComponent<MeshRenderer>().material.color = FindObjectOfType<ColorController>().GetColor();
        var objects = GameObject.FindGameObjectsWithTag("PickUp");
        foreach (var item in objects)
        {
            foreach (Transform cube in item.GetComponent<Transform>())
            {
                cube.GetComponent<MeshRenderer>().material.color = FindObjectOfType<ColorController>().GetColor();
            }
        }

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
