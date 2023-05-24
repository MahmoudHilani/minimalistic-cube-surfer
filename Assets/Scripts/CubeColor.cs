using UnityEngine;
using UnityEngine.UI;

public class CubeColor : MonoBehaviour
{

    private void FixedUpdate()
    {
        if (FindObjectOfType<ColorController>().GetColor() == gameObject.GetComponent<Image>().color)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
    }

    public void ChangeColor()
    {
        FindObjectOfType<ColorController>().ChangeCubeColor(gameObject.GetComponent<Image>().color);
    }

}
