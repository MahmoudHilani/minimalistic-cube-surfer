
using UnityEngine;

public class PickUpAnimation : MonoBehaviour
{
    public void PlayAnimation()
    {
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<Animator>().enabled = true;
    }
}
