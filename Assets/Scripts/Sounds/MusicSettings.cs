using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicSettings : MonoBehaviour
{
    public AudioSource audioSource;
    public bool isOn;
    public GameObject musicCheckmark;
    public GameObject musicCheckmarkOff;
    // Start is called before the first frame update
    void Start(){
        musicCheckmark = GameObject.FindWithTag("CheckMusic");
        musicCheckmarkOff = GameObject.FindWithTag("CheckMusicOff");

        isOn = intToBool(PlayerPrefs.GetInt("currentMusic", 1));
        if(isOn){
            //continue playing if is on
            audioSource.mute = false;
            isOn = true;
            musicCheckmark.SetActive(true);
            musicCheckmarkOff.SetActive(false);
        }
        else{
            audioSource.mute = true;
            isOn = false;
            musicCheckmark.SetActive(false);
            musicCheckmarkOff.SetActive(true);
        }
        print("Prefs");
        print(boolToInt(isOn));
        print("EndPrefs");
    }

    public void ButtonClicked(){
        if(isOn){
            //turning music off; 0
            audioSource.mute = true;
            isOn = false;
            musicCheckmark.SetActive(false);
            musicCheckmarkOff.SetActive(true);
        }
        else{
            //turning music on, 1
            audioSource.mute = false;
            isOn = true;
            musicCheckmark.SetActive(true);
            musicCheckmarkOff.SetActive(false);
        }
        print("Prefs");
        print(boolToInt(isOn));
        print("EndPrefs");
        PlayerPrefs.SetInt("currentMusic", boolToInt(isOn));
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
