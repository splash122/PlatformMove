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
    public ParticleSystem particleSystem;
    Vector3 previousPosition;
    Vector3 lastMoveDirection;
    bool leftMove;
    bool rightMove;
    bool upMove;
    bool downMove;
    
    private void Awake()
    {
        rbThing = GetComponent<Rigidbody>();
    }

    void Start()
    {
        old_pos = rbThing.transform.position;
        changeHappened = false;
        lastMoveDirection = Vector3.zero;
    }
    
    /*void Update()
    {
        //rbThing.transform.rotation = GameObject.FindWithTag("Floor").transform.rotation;
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
    }*/

    /*void FixedUpdate(){
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 7;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        // Left side of car
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward * 2), out hit,
                1f,
                layerMask))
        {
            print("It's draw ray");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward * 2), Color.blue,5);
            Debug.Log("Did Hit");
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back * 2), out hit,
                1f,
                layerMask))
        {
            print("It's draw ray");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back * 2), Color.green, 5);
            Debug.Log("Did Hit");
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right * 2), out hit,
                1f,
                layerMask))
        {
            print("It's draw ray");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right * 2), Color.black,5);
            Debug.Log("Did Hit");
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left * 2), out hit,
                1f,
                layerMask))
        {
            print("It's draw ray");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left * 2), Color.red, 5);
            Debug.Log("Did Hit");
        }



        if(rbThing.transform.position != previousPosition) {
            lastMoveDirection = (rbThing.transform.position - previousPosition).normalized;
            print("lastMoveDirection");
            print(lastMoveDirection);

            if(lastMoveDirection.x>0 && lastMoveDirection.x>lastMoveDirection.z) {
                print("It's right direction");
                if (hit.collider)
                {
                    print("It's Thing");
                    transform.position = new Vector3(5f, old_pos.y, old_pos.z);
                }
            }

            else if(lastMoveDirection.x<0 && lastMoveDirection.x<lastMoveDirection.z) {
                print("It's left direction");
                if (hit.collider)
                {
                    print("It's Collider");
                    transform.position = new Vector3(-5f, old_pos.y, old_pos.z);
                }
            }
            else if(lastMoveDirection.z>0 && lastMoveDirection.z>lastMoveDirection.x){
                print("It's forward direction");
                    if (hit.collider)
                    {
                        print("It's Thing");
                        transform.position = new Vector3(old_pos.x,old_pos.y,5f);
                    }
            }
            else if(lastMoveDirection.z<0 && lastMoveDirection.z<lastMoveDirection.x){
                print("It's back direction");
                    if (hit.collider != null && downMove)
                    {
                        print("It's Thing");
                        transform.position = new Vector3(old_pos.x,old_pos.y,-5f);
                    }
            }
            previousPosition = rbThing.transform.position;
                }
    }*/


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            particleSystem.Play();
        }
    }
}

