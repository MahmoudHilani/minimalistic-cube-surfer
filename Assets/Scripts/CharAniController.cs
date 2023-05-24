using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAniController : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void WonAni()
    {
        animator.SetBool("Win", true);
    }

    public void LostAni()
    {
        animator.SetBool("Lose", true);
    }
}
