using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CubeMover : MonoBehaviour
{
    public float x_width;
    public float z_width;
    public Rigidbody cube;
    public InputAction move;
    public Transform Target;
    public float angle;
    private Vector3 newToGo;
    public Player playerMover;


    private void Awake()
    {
        
    }
    public void Start()
    {
        x_width = cube.transform.localScale.x;
        z_width = cube.transform.localScale.z;
        cube = GetComponent<Rigidbody>();
    }

    public IEnumerator Move(Vector2 direction)
    {
        for (int i = 0; i < 1; i++)
        {
            yield return null;
            //newToGo = new Vector3(direction.y, 0, -direction.x);
            //print("newVector");
            //print(newToGo);
            //transform.RotateAround(Target.position, newToGo.normalized, angle);
            /*playerMover.MovePlayer();
            print("---------");
            print(GetCorner(GameObject.FindWithTag("Floor"),Corner.TopLeft));
            print(GetCorner(GameObject.FindWithTag("Floor"),Corner.TopRight));
            print(GetCorner(GameObject.FindWithTag("Floor"),Corner.BottomLeft));
            print(GetCorner(GameObject.FindWithTag("Floor"),Corner.BottomRight));*/
        }
    }
    
    public enum Corner
    {
        TopLeft,
        TopRight,
        BottomRight,
        BottomLeft
    }

    // Returns coordinates of specified corner of a game object

    public static Vector3 GetCorner(GameObject gameObject, Corner corner)
    {
        Vector3 extents = gameObject.GetComponent<Renderer>().bounds.extents;
        /*print("extents");
        print(extents.x);
        print(extents.y);
        print(extents.z);
        print("end extents");*/
        Vector3 cornerPosition = gameObject.transform.position; 

        if (corner == Corner.TopLeft)
        {
            cornerPosition.x -= extents.x;
            cornerPosition.y += extents.y;
        }
        else if (corner == Corner.TopRight)
        {
            cornerPosition.x += extents.x;
            cornerPosition.y += extents.y;
        }
        else if (corner == Corner.BottomRight)
        {
            cornerPosition.x += extents.x;
            cornerPosition.y -= extents.y;
        }
        else if (corner == Corner.BottomLeft)
        {
            cornerPosition.x -= extents.x;
            cornerPosition.y -= extents.y;
        }

        return cornerPosition;
    }

}


        