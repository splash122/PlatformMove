using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotMovable : MonoBehaviour
{
    Rigidbody notMovable;

    
    private void Awake()
    {
        notMovable = GetComponent<Rigidbody>();
    }

    void Start()
    {
    }

    void Update()
    {
        notMovable.transform.rotation = GameObject.FindWithTag("Floor").transform.rotation;
    }
}
