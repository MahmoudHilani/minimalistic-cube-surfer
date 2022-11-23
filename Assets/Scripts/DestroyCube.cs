using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCube : MonoBehaviour
{

    [SerializeField] private AudioSource Win1;
    [SerializeField] private AudioSource Win2;
    [SerializeField] private AudioSource Win3;
    [SerializeField] private AudioSource Win4;
    [SerializeField] private AudioSource Win5;
    [SerializeField] private AudioSource Obstruct;

    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstruction"))
        {
            if (Obstruct != null)
            {
                Obstruct.Play();

            }
            RemoveCube(other);
        }
        if (other.CompareTag("Stair"))
        {
            if (gameObject.tag == "Player")
            {
                FindObjectOfType<GameManager>().CompleteLevel();

                return;
            }
            other.tag = "Untagged";
            FindObjectOfType<PlayerInventory>().AddMultiplier();
            other.enabled = false;
            Debug.Log(FindObjectOfType<PlayerInventory>().Multiplier);

            RemoveCube(other);
        }
        if (other.name == "Stair 1")
        {
            Win1.Play();
        }
        if (other.name == "Stair 2")
        {
            Win2.Play();
        }
        if (other.name == "Stair 3")
        {
            Win3.Play();
        }
        if (other.name == "Stair 4")
        {
            Win4.Play();
        }
        if (other.name == "Stair 5")
        {
            Win5.Play();
        }
    }

    public void RemoveCube(Collider other)
    {
        transform.parent = other.transform;

    }
}
