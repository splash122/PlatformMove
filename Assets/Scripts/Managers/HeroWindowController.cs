using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroWindowController : MonoBehaviour
{
    public GameObject textNotEnough;
    // Start is called before the first frame update
    void Start()
    {
        textNotEnough = GameObject.FindWithTag("TextNotEnough");
        textNotEnough.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
