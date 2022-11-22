
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool dead = false;
    public float forwardSpeed = 10f;
    public float sideSpeed = 5f;
    private float boostTimer;
    private bool boosting;
    

    void Start()
    {
        boostTimer = 0;
        boosting = false;
    }


    void FixedUpdate()
    {

        if (dead)
        {
            
            return;
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + forwardSpeed * Time.deltaTime);


        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x - sideSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + sideSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        if (boosting)
        {
            boostTimer += Time.fixedDeltaTime;

            if (boostTimer >= 1.5f)
            {
                forwardSpeed = 10f;
                boostTimer = 0;
                boosting = false;
            }
        }
    }

    public void SpeedUp()
    {


        boosting = true;
        forwardSpeed = 20f;
    }
}
