
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform PlayerPos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().transform;
        transform.position = new Vector3(PlayerPos.position.x, transform.position.y, PlayerPos.position.z);
    }
}
