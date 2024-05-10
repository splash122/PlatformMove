using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody player;
    public Rigidbody thing;
    public CubeMover floor;
    private Vector3 scale; 
    private Vector3 old_pos;
    public InputAction move;
    private Vector2 newToGo;
    public Transform TargetVertical;
    public Transform TargetHorizontal;
    public float angle;
    public BackGround backGround;
    

    private void Awake()
    {
        move.Enable();
        move.performed += context => { StartCoroutine(Move(context.ReadValue<Vector2>())); };
        SwipeDetection.instance.swipePerformed += context => { StartCoroutine(Move(context)); };
    }
    void Start()
    {
        thing = GameObject.FindWithTag("Thing").GetComponent<Rigidbody>();
        player = GetComponent<Rigidbody>();
        floor = GameObject.FindWithTag("Floor").GetComponent<CubeMover>();
    }
    public IEnumerator Move(Vector2 direction)
    {
        for (int i = 0; i < 1; i++)
        {
            yield return null;
            //print("Direction");
            //Debug.Log(direction);
            //Player move
            transform.position = new Vector3(transform.position.x+direction.x/5, 1, transform.position.z+direction.y/5);
            newToGo = new Vector3(-direction.y, 0, -direction.x);
            //Camera move
            if (direction.y != 0)
                print("Y");
            {
                Camera.main.transform.RotateAround(TargetVertical.position, newToGo.normalized, angle);
                if (direction.y > 0)
                {
                    //thing.position = Vector3.MoveTowards(transform.position, new Vector3(0,0,6), 1f);
                }
                if (direction.y < 0)
                {
                    //thing.position = Vector3.MoveTowards(transform.position, new Vector3(0,0,-6), 1f);
                }
            }
            if(direction.x < 0 && transform.position.x<0)
            {
                print("X");
                Camera.main.transform.Rotate(0,0,-angle);
                Physics.gravity = new Vector3(-3, 0, 0);
            }
            else if(direction.x > 0 && transform.position.x>0)
            {
                print("X");
                Camera.main.transform.Rotate(0,0,angle);
                Physics.gravity = new Vector3(3, 0, 0);
                //thing.position = Vector3.MoveTowards(transform.position, Vector3.right, 1f);
            }



            backGround.transform.rotation = Camera.main.transform.rotation;
            /*if (transform.position.x < 0)
            {
                //newToGo = new Vector3(direction.y, 0, -direction.x);
                //print("newVector");
                //print(newToGo);
                //Camera.main.transform.RotateAround(Target.position, newToGo.normalized, angle);
                Camera.main.transform.rotation = Quaternion.Euler(new Vector3(Camera.main.transform.rotation.x,Camera.main.transform.rotation.y,Camera.main.transform.rotation.z+5));
                backGround.transform.rotation = Camera.main.transform.rotation;
                print("rotation camera lowX");
                print(Camera.main.transform.rotation);
                print(backGround.transform.rotation);
            }
            else if(transform.position.x > 0)
            {
                Camera.main.transform.rotation = Quaternion.Euler(new Vector3(Camera.main.transform.rotation.x,Camera.main.transform.rotation.y,Camera.main.transform.rotation.z-5));
                backGround.transform.rotation = Camera.main.transform.rotation;
                print("rotation camera bigX");
                print(Camera.main.transform.rotation);
            }
            if (transform.position.z < 0)
            {
                Camera.main.transform.rotation = Quaternion.Euler(new Vector3(Camera.main.transform.rotation.x+5,Camera.main.transform.rotation.y,Camera.main.transform.rotation.z));
                backGround.transform.rotation = Camera.main.transform.rotation;
                print("rotation camera lowZ");
                print(Camera.main.transform.rotation);
            }
            else if (transform.position.z > 0)
            {
                Camera.main.transform.rotation = Quaternion.Euler(new Vector3(Camera.main.transform.rotation.x-5,Camera.main.transform.rotation.y,Camera.main.transform.rotation.z));
                backGround.transform.rotation = Camera.main.transform.rotation;
                print("rotation camera bigZ");
                print(Camera.main.transform.rotation);
            }*/
            /*
            print("----corners-----");
            print(CubeMover.GetCorner(GameObject.FindWithTag("Floor"),CubeMover.Corner.TopLeft));
            print(CubeMover.GetCorner(GameObject.FindWithTag("Floor"),CubeMover.Corner.TopRight));
            print(CubeMover.GetCorner(GameObject.FindWithTag("Floor"),CubeMover.Corner.BottomLeft));
            print(CubeMover.GetCorner(GameObject.FindWithTag("Floor"),CubeMover.Corner.BottomRight));
            print("-----end corners-----");
            */
        }
    }

    void Update()
    {
        //player.transform.rotation = GameObject.FindWithTag("Floor").transform.rotation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "HouseMain")
        {
            SceneManager.LoadScene("FirstScreen");
        }

        if (collision.gameObject.tag == "Thing")
        {
            SceneManager.LoadScene("FirstScreen");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
            CoinsText.coinsCount += 1;
        }
    }
}
