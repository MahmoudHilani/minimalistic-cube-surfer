using UnityEngine;
using UnityEngine.UI;

public class CubeColor : MonoBehaviour
{
    public GameObject cube;
    public Material[] materials;
    private int ColorValue;
    public Renderer meshRenderer;
    private Button button;

    void Start()
    {

        meshRenderer = cube.GetComponent<MeshRenderer>();
    }

    public void ChangeColor()
    {
        if (button.name == "Color1")
        {
            meshRenderer.material = materials[1];
        }

        if (button.name == "Color2")
        {
            meshRenderer.material = materials[2];
        }
    }

}
