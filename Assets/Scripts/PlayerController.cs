
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject Character;
    public GameObject JointsAlpha;
    public Material Secret;
    public AudioSource SecretAudio;
    public Material SecretJoint;
    public GameManager gameManager;
    public GameObject PickUpAni;
    public Color defaultColor;
    [SerializeField] private AudioSource PickUpSound;
    [SerializeField] private AudioSource CoinSound;
    [SerializeField] private AudioSource SpeedSound;
    [SerializeField] private AudioSource DeathSound;

    private void Start()
    {
        defaultColor = FindObjectOfType<ColorController>().GetColor();


        Character = GameObject.FindGameObjectWithTag("MainAlpha");
        JointsAlpha = GameObject.FindGameObjectWithTag("JointsAlpha");
        Secret = GameObject.FindGameObjectWithTag("Alpha").GetComponent<SkinnedMeshRenderer>().material;
        SecretAudio = GameObject.FindGameObjectWithTag("MainAlpha").GetComponent<AudioSource>();
        SecretJoint = GameObject.FindGameObjectWithTag("Joint").GetComponent<SkinnedMeshRenderer>().material;

        Character.GetComponent<SkinnedMeshRenderer>().material = FindObjectOfType<ColorController>().getCharColor();
        JointsAlpha.GetComponent<SkinnedMeshRenderer>().material = FindObjectOfType<ColorController>().getJointsColor();
    }
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
                if (DeathSound != null)
                {
                    DeathSound.Play();

                }
                if (gameManager != null)
                {
                    gameManager.LoseLevel();

                }

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
        if (other.tag == "Secret")
        {
            GameManager gm = FindObjectOfType<GameManager>();
            gm.CompleteLevel();
            SecretAudio.Play();
            Character.GetComponent<SkinnedMeshRenderer>().material = Secret;
            JointsAlpha.GetComponent<SkinnedMeshRenderer>().material = SecretJoint;
            FindObjectOfType<ColorController>().switchCharColors();
            Destroy(other.gameObject);
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
            GameObject childCube;
            if (transform.tag == "Player")
            {
                childCube = Instantiate(other.transform.GetChild(i).gameObject, transform.position, Quaternion.identity, transform);
                transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                childCube.transform.localPosition = new Vector3(0, -transform.childCount + 2, 0);
                FindObjectOfType<PickUpAnimation>().PlayAnimation();
                // childCube.GetComponent<Material>().color = FindObjectOfType<ColorController>().GetColor();
                // childCube.GetComponent<Material>().SetColor("_color", defaultColor);

            }
            else
            {

                childCube = Instantiate(other.transform.GetChild(i).gameObject, transform.position, Quaternion.identity, transform.parent);
                transform.parent.position = new Vector3(transform.parent.position.x, transform.parent.position.y + 1, transform.parent.position.z);
                childCube.transform.localPosition = new Vector3(0, -transform.parent.childCount + 2, 0);
                FindObjectOfType<PickUpAnimation>().PlayAnimation();

            }
            childCube.GetComponent<MeshRenderer>().material.color = defaultColor;
        }

        Destroy(other.gameObject);

    }
}


