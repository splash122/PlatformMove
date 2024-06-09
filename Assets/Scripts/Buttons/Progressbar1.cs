using UnityEngine;
using UnityEngine.UI;

public class Progressbar1 : MonoBehaviour
{
    public float fillSpeed = 0.5f;
    private float targetProgress = 0;
    public Slider slider;
    private ParticleSystem particleSystem;
    public Text coinsText;
    public static int neededCount;
    private float resultProgress;
    private float realProgress;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Awake()
    {

        slider = gameObject.GetComponent<Slider>();
        //particleSystem = GameObject.Find("ProgressBarParticles").GetComponent<ParticleSystem>();
    }

    public void Update()
    {
        /*if (slider.value < targetProgress)
        {
            slider.value += fillSpeed * Time.deltaTime;
            if (!particleSystem.isPlaying)
            {
               // particleSystem.Play();
            }
        }
        else
        {
            particleSystem.Stop();
        }*/
    }

    public void IncrementProgress(float result)
    {
        if(result<1){
            slider.value = result;
        }
        if(result>=1){
            slider.value = 1;
        }
    }
}