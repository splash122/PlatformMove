using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThingsBehavior : MonoBehaviour
{
    public bool moveDirectionX;
    Rigidbody rbThing;
    private Vector3 old_pos;
    private bool changeHappened;
    
    private void Awake()
    {
        rbThing = GetComponent<Rigidbody>();
    }

    void Start()
    {
        old_pos = rbThing.transform.position;
        changeHappened = false;
    }
    
    void Update()
    {
        rbThing.transform.rotation = GameObject.FindWithTag("Floor").transform.rotation;
        if (old_pos != rbThing.transform.position && moveDirectionX)
            
        {
            //Debug.Log("car");
            rbThing.constraints = RigidbodyConstraints.FreezePositionZ;
            if (changeHappened)
            {
                rbThing.constraints = RigidbodyConstraints.FreezePositionX;
            }
        }
        else if (old_pos != rbThing.transform.position && moveDirectionX==false)
        {
            rbThing.constraints = RigidbodyConstraints.FreezePositionX;
            if (changeHappened)
            {
                rbThing.constraints = RigidbodyConstraints.FreezePositionZ;
            }
        }
    }
    

    void OnTriggerEnter(Collider change)
    {
        if (change.tag == "Rotator")
        {
            changeHappened = true;
            Debug.Log(("changehappened"));
        }
        if (change.gameObject.tag == "Coin")
        {
            change.enabled = false;
        }
    }
}

