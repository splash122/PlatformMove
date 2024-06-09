using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeExample : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Floor1")
        {
            //transform.parent = other.transform;
            transform.rotation = other.transform.rotation;
            Physics.gravity = new Vector3(0, -3, 0);
            //transform.position = Vector3.MoveTowards(transform.position, new Vector3(-4,5,0), 3f);

        }
    }
}
