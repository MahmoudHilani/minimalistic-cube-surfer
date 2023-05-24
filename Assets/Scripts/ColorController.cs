using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour
{
    static ColorController instance;
    static Color cubeColor = new Color(0.81f, 0.215f, 0f, 1f);
    public Material characterColor;
    public Material goldenColor;
    public Material jointsColor;
    public Material blackJoints;


    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }


    public void ChangeCubeColor(Color color)
    {

        cubeColor = color;

    }

    public Color GetColor()
    {
        return cubeColor;
    }

    public Material getCharColor()
    {
        return characterColor;
    }
    public Material getJointsColor()
    {
        return jointsColor;
    }
    public void switchCharColors()
    {
        characterColor = goldenColor;
        jointsColor = blackJoints;
    }

}
