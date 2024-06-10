using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeHeroes : MonoBehaviour
{
    private GameObject restart;
    private GameObject resume;


    //public Object girlPrefab;
    //public Object boyPrefab;
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    //public GameObject[] myPrefab;
    public Transform parentObject;
    public Transform[] allchildren;

    // This script will simply instantiate the Prefab when the game starts.
    void Start() {
        restart = GameObject.FindWithTag("Restart");
        resume = GameObject.FindWithTag("CoinsNotEnoughWindow");
        restart.SetActive(false);
        resume.SetActive(false);
        string hero = PlayerPrefs.GetString("Hero", "Player");
        print("Hero");
        print(hero);
        allchildren = new Transform[parentObject.transform.childCount];
        for (int i = 0; i < allchildren.Length; i++) {
            allchildren[i] = parentObject.transform.GetChild(i);
            if (allchildren[i].name == hero) {
            }
            else {
                allchildren[i].gameObject.SetActive(false);
            }
        }

    }
    void Update(){

    }
        // Instantiate at position (0, 0, 0) and zero rotation.
        //Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);

}
