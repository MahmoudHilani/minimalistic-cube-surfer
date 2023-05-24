
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private Slider slider;

    private float fillSpeed = 0.02f;
    private float targetProgress = 0;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }


    void Start()
    {
        IncrementProgress(1f);
    }


    void FixedUpdate()
    {
        if (slider.value < targetProgress)
        {
            slider.value += fillSpeed * Time.fixedDeltaTime;
        }
    }

    public void IncrementProgress(float newProgress)
    {
        targetProgress = slider.value + newProgress;
    }
}
