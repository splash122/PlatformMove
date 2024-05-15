using System;
using UnityEngine;
using UnityEngine.UI;

public class Progressbar1 : MonoBehaviour
{
    public float fillSpeed = 0.5f;
    private float targetProgress = 0;
    public Slider slider;
    private GameObject coin;

    public Text coinsText;
    public static int coinsCount = 0;
    public static float neededCount;
    private float resultProgress;
    // Start is called before the first frame update
    void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    private void Update()
    {
        if (slider.value < targetProgress)
        {
            slider.value += fillSpeed * Time.deltaTime;
        }

    }
    
    public void IncrementProgress()
    {
        coinsCount += 1;
        neededCount = 2f;
        resultProgress = Mathf.Round(coinsCount) / Mathf.Round(neededCount);
        print("newProgress");
        targetProgress = slider.value + resultProgress;
    }
}