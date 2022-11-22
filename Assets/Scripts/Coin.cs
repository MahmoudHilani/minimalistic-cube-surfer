
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{

    [SerializeField] private AudioSource CoinSound;
    public GameObject Player;

    void Update()
    {
        transform.Rotate(0, 0, 0.25f);
    }

    private void OnTriggerEnter(Collider other)
    {
        CoinSound.Play();
        gameObject.SetActive(false);
        Player.GetComponent<PlayerInventory>().CoinCollected();
    }
}
