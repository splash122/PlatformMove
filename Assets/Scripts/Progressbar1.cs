using UnityEngine;
using UnityEngine.UI;

public class Progressbar1 : MonoBehaviour
{
    public float fillSpeed = 0.5f;
    private float targetProgress = 0;
    public Slider slider;
    private GameObject coin;
    private ParticleSystem particleSystem;
    public Text coinsText;
    public static int coinsCount = 0;
    public static float neededCount;
    private float resultProgress;
    // Start is called before the first frame update
    void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
        particleSystem = GameObject.Find("ProgressBarParticles").GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (slider.value < targetProgress)
        {
            slider.value += fillSpeed * Time.deltaTime;
            if (!particleSystem.isPlaying)
            {
                particleSystem.Play();
            }
        }
        else
        {
            particleSystem.Stop();
        }
    }

    public void IncrementProgress(int coin)
    {
        coinsCount = coin;
        neededCount = 2;
        resultProgress = Mathf.Round(coinsCount) / Mathf.Round(neededCount);
        targetProgress = slider.value + resultProgress;
        print("newProgress: slider and target");
        print(slider.value);
        print(resultProgress);
        print(targetProgress);
    }
}