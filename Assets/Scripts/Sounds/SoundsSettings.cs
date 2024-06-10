using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundsSettings : MonoBehaviour
{
    public AudioSource audioSource;
    public bool isOn;
    public GameObject soundsCheckmark;
    public GameObject soundsCheckmarkOff;
    // Start is called before the first frame update
    void Start(){
        string heroName = PlayerPrefs.GetString("Hero", "Player");
        GameObject hero = GameObject.Find(heroName);
        print("HeroForMusicFound");
        print(hero);
        //AudioSource girlSource = GameObject.FindGameObjectWithTag("GameObject1").GetComponent<AudioSource>();
        //GetComponent<AudioSource>().clip = girlSource.clip;
        //audioSource = hero.GetComponent<AudioSource>();

        soundsCheckmark = GameObject.FindWithTag("CheckSounds");
        soundsCheckmarkOff = GameObject.FindWithTag("CheckSoundsOff");

        isOn = intToBool(PlayerPrefs.GetInt("currentSound", 1));
        if(isOn){
            //continue playing if is on
            audioSource.mute = false;
            isOn = true;
            soundsCheckmark.SetActive(true);
            soundsCheckmarkOff.SetActive(false);
        }
        else{
            audioSource.mute = true;
            isOn = false;
            soundsCheckmark.SetActive(false);
            soundsCheckmarkOff.SetActive(true);
        }
        print("Prefs");
        print(boolToInt(isOn));
        print("EndPrefs");
        PlayerPrefs.SetInt("currentSound", boolToInt(isOn));
    }

    public void ButtonClicked(){
        if(isOn){
            //turning sounds off; 0
            audioSource.mute = true;
            isOn = false;
            soundsCheckmark.SetActive(false);
            soundsCheckmarkOff.SetActive(true);
        }
        else{
            //turning sounds on, 1
            audioSource.mute = false;
            isOn = true;
            soundsCheckmark.SetActive(true);
            soundsCheckmarkOff.SetActive(false);
        }
        print("Prefs");
        print(boolToInt(isOn));
        print("EndPrefs");
        PlayerPrefs.SetInt("currentSound", boolToInt(isOn));
    }

    public int boolToInt(bool val)
    {
        if (val)
            return 1;
        else
            return 0;
    }

    public bool intToBool(int val)
    {
        if (val != 0)
            return true;
        else
            return false;
    }

}

