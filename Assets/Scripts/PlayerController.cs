
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject PickUpAni;
    [SerializeField] private AudioSource PickUpSound;
    [SerializeField] private AudioSource CoinSound;
    [SerializeField] private AudioSource SpeedSound;
    [SerializeField] private AudioSource DeathSound;


    void FixedUpdate()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).position.y < -100)
            {
                if (transform.GetChild(i).tag != "MainCamera" || transform.GetChild(i).tag != "Character")
                {
                    GameObject.Destroy(transform.GetChild(i).gameObject);
                }
            }
            if (transform.position.y <= -80)
            {
                DeathSound.Play();
                gameManager.LoseLevel();

            }


        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "PickUp")
        {
            PickUpSound.Play();
            AddCube(other);
        }
        if (other.tag == "Coin")
        {
            CoinSound.Play();
        }

        if (gameObject.tag == "Player")
        {
            if (other.tag == "Obstruction")
            {
                transform.GetComponent<BoxCollider>().enabled = false;
                transform.GetComponent<Rigidbody>().useGravity = false;
                DeathSound.Play();
                gameManager.LoseLevel();
            }
            if (other.tag == "Death")
            {
                transform.GetComponent<BoxCollider>().enabled = true;
                transform.GetComponent<Rigidbody>().useGravity = true;
                DeathSound.Play();
                other.enabled = false;

                gameManager.LoseLevel();
            }
            if (other.tag == "End")
            {

                gameManager.CompleteLevel();
            }

        }
        if (other.tag == "SpeedBoost")
        {
            SpeedSound.Play();
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().SpeedUp();
        }



    }




    private void AddCube(Collider other)
    {

        for (int i = 0; i < other.transform.childCount; i++)
        {
            other.enabled = false;

            other.transform.GetChild(i).GetComponent<BoxCollider>().enabled = true;
            other.transform.GetChild(i).GetComponent<Rigidbody>().useGravity = true;

            if (transform.tag == "Player")
            {
                var childCube = Instantiate(other.transform.GetChild(i).gameObject, transform.position, Quaternion.identity, transform);
                transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                childCube.transform.localPosition = new Vector3(0, -transform.childCount +2, 0);
                FindObjectOfType<PickUpAnimation>().PlayAnimation();

            }
            else
            {
                var childCube = Instantiate(other.transform.GetChild(i).gameObject, transform.position, Quaternion.identity, transform.parent);
                transform.parent.position = new Vector3(transform.parent.position.x, transform.parent.position.y + 1, transform.parent.position.z);
                childCube.transform.localPosition = new Vector3(0, -transform.parent.childCount + 2, 0);
                FindObjectOfType<PickUpAnimation>().PlayAnimation();
            }
        }
        Destroy(other.gameObject);

    }
}


