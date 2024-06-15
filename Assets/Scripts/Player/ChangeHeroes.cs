using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeHeroes : MonoBehaviour
{
    public GameObject restart;
    public GameObject resume;


    //public Object girlPrefab;
    //public Object boyPrefab;
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    //public GameObject[] myPrefab;
    public Transform parentObject;
    public Transform[] allchildren;
    public Transform parentCarObject;
    public Transform[] allCarchildren;
    // This script will simply instantiate the Prefab when the game starts.
    void Start() {
        restart = GameObject.FindWithTag("Restart");
        resume = GameObject.FindWithTag("CoinsNotEnoughWindow");
        //restart.SetActive(false);
        //resume.SetActive(false);
        string hero = PlayerPrefs.GetString("HeroChosen", "Player");
        print("Hero");
        print(hero);
        allchildren = new Transform[parentObject.transform.childCount];
        for (int i = 0; i < allchildren.Length; i++) {
            allchildren[i] = parentObject.transform.GetChild(i);
            if (allchildren[i].name == hero) {
                PlayerPrefs.SetString("HeroChosen", hero);
            }
            else {
                allchildren[i].gameObject.SetActive(false);
            }
        }

        string car = PlayerPrefs.GetString("CarChosen", "CarDefault");
        print("Car");
        print(car);
        allCarchildren = new Transform[parentCarObject.transform.childCount];
        for (int i = 0; i < allCarchildren.Length; i++) {
            allCarchildren[i] = parentCarObject.transform.GetChild(i);
            if (allCarchildren[i].name == car) {
                PlayerPrefs.SetString("CarChosen", car);
            }
            else {
                allCarchildren[i].gameObject.SetActive(false);
            }
        }

    }
    void Update(){

    }
        // Instantiate at position (0, 0, 0) and zero rotation.
        //Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);

}
