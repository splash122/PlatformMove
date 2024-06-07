using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody player;
    private Rigidbody thing;
    private CubeMover floor;
    private Vector3 scale;
    public InputAction move;
    private Vector2 newToGo;
    public Transform TargetVertical;
    public float angle;
    public BackGround backGround;
    public Vector3 playerToGo;
    public float range;
    private bool isSwipedLeft;
    private bool isSwipedRight;
    private bool isSwipedUp;
    private bool isSwipedDown;
    private Vector3 oldTrans;
    private GameObject restart;
    private GameObject resume;
    public Player playGameObj;
    public CoinsManager coinsText;
    public Progressbar1 progressBar;
    public ThingsBehavior thingsBehavior;
    public float movementSpeed;
    private float dirX, dirZ;
    public bool canMove = true;
    int madeMovesRight;
    int madeMovesLeft;
    int madeMovesUp;
    int madeMovesDown;
    public int gainedCoins;
    AudioSource coinsSound;
    public MusicSettings musicSettings;
    public bool isOn;
    public SoundsSettings soundsSettings;
    public bool isOnSounds;



    /*private void OnEnable()
    {
        print("enabling");
        
        move.Enable();
        move.performed += context => { StartCoroutine(Move(context.ReadValue<Vector2>())); };
        SwipeDetection.instance.swipePerformed += context => { StartCoroutine(Move(context)); };
    }
    private void OnDisable()
    {
        print("disabling");
        move.performed -= context => { StartCoroutine(Move(context.ReadValue<Vector2>())); };
        SwipeDetection.instance.swipePerformed -= context => { StartCoroutine(Move(context)); };   
        move.Disable();
    }*/

    void Start()
    {
        coinsSound = GetComponent<AudioSource>();
        playGameObj = GetComponent<Player>();
        player = GetComponent<Rigidbody>();
        restart = GameObject.FindWithTag("Restart");
        resume = GameObject.FindWithTag("CoinsNotEnoughWindow");
        restart.SetActive(false);
        resume.SetActive(false);
        isOn = musicSettings.intToBool(PlayerPrefs.GetInt("currentMusic", 1));
        isOnSounds = soundsSettings.intToBool(PlayerPrefs.GetInt("currentSound", 1));
        print("Loading music from prefs");
        print(isOn);
        print("End loading");
        if(isOn){
            //continue playing if is on
            musicSettings.audioSource.mute = false;
            isOn = true;
        }
        else{
            musicSettings.audioSource.mute = true;
            isOn = false;
        }
        print("Prefs");
        print(musicSettings.boolToInt(isOn));
        print("EndPrefs");
        PlayerPrefs.SetInt("currentMusic", musicSettings.boolToInt(isOn));
        print("Loading sounds from prefs");
        print(isOnSounds);
        print("End loading");
        if(isOnSounds){
            //continue playing sounds if is on
            soundsSettings.audioSource.mute = false;
            isOnSounds = true;
        }
        else{
            soundsSettings.audioSource.mute = true;
            isOnSounds = false;
        }
        print("Prefs");
        print(soundsSettings.boolToInt(isOnSounds));
        print("EndPrefs");
        PlayerPrefs.SetInt("currentSound", soundsSettings.boolToInt(isOnSounds));
    }

    void Update(){
        if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)
        {
            //Debug.Log("Nothing pressed");

        }
        else {
            Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            oldTrans = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            dirX = Input.GetAxis("Horizontal");
            dirZ = Input.GetAxis("Vertical");
            player.velocity = new Vector3(dirX, 0, dirZ) * 7f;
            Vector3 targetForwardDirection = player.velocity;

            //get the rotation that corresponds to facing in the direction of the velocity
            Quaternion targetRotation = Quaternion.LookRotation(targetForwardDirection);

            //explicity set the rotation of the rigidbody
            player.MoveRotation(targetRotation);
            if (canMove) {
                if (dirZ > 0)
                {
                    print("YUp");
                    isSwipedUp = true;

                    if (transform.position.z > 0)
                    {
                        madeMovesUp++;
                        print("madeMovesUp");
                        print(madeMovesUp);
                        print("Rotation");
                        print(backGround.transform.rotation);
                        if (backGround.transform.rotation.x > 0.2) {
                            Camera.main.transform.RotateAround(TargetVertical.position, Vector3.left, angle);
                        }
                        print("CameraY");
                        Physics.gravity = new Vector3(0, 0, 3);
                        //canMove = false;
                    }
                }
                if (dirZ < 0)
                {
                    print("YDown");
                    isSwipedDown = true;

                    if (transform.position.z < 0)
                    {
                        madeMovesDown++;
                        print("madeMovesDown");
                        print(madeMovesDown);
                        print("Rotation");
                        print(backGround.transform.rotation);
                        if (backGround.transform.rotation.x < 0.3) {
                            Camera.main.transform.RotateAround(TargetVertical.position, Vector3.right, angle);
                        }
                        print("CameraY");
                        Physics.gravity = new Vector3(0, 0, -3);
                        //canMove = false;
                    }
                }
                if (dirX < 0)
                {
                    print("DirectionXLeft");
                    isSwipedLeft = true;

                    if (transform.position.x < 0)
                    {
                        madeMovesLeft++;
                        print("madeMovesLeft");
                        print(madeMovesLeft);
                        print("Rotation");
                        print(backGround.transform.rotation);
                        if (backGround.transform.rotation.z > -0.05) {
                            Camera.main.transform.Rotate(0, 0, -angle);
                        }
                        print("CameraX");
                        Physics.gravity = new Vector3(-3, 0, 0);
                        //canMove = false;
                    }
                }
                else if (dirX > 0)
                {
                    print("DirectionXRight");
                    isSwipedRight = true;

                    print(madeMovesRight);
                    if (transform.position.x > 0)
                    {
                        madeMovesRight++;
                        print("madeMovesRight");
                        print(madeMovesRight);
                        print("Rotation");
                        print(backGround.transform.rotation);
                        if (backGround.transform.rotation.z < 0.05) {
                            Camera.main.transform.Rotate(0, 0, angle);
                        }
                        print("CameraX");
                        print("Gravity enabled");
                        Physics.gravity = new Vector3(3, 0, 0);
                        //canMove = false;
                    }
                }
                backGround.transform.rotation = Camera.main.transform.rotation;
            }
            //canMove = true;
        }
    }
/*
    void FixedUpdate(){

        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 7;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        
        if (isSwipedLeft)
        {
            print("before raycastLeft");
          if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward * 2), out hit,
                        1f,
                        layerMask))
          { 
              print("It's draw ray");
              Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward * 2), Color.blue,5);
              Debug.Log("Did Hit");
              {
                  //Physics.IgnoreLayerCollision(8,9);
                  //GameObject.FindWithTag("Player").GetComponent<Rigidbody>().isKinematic = true;
                  //player.MovePosition(transform.position + new Vector3(0,0,0) * Time.deltaTime * 5f);
                  //canMove = false;
                  //Physics.gravity = new Vector3(0,-20,0);
                  //transform.position = new Vector3(-10f,10,20);
              }
          }
        }
        isSwipedLeft = false;
        
        if (isSwipedRight) 
        {
            print("before raycastRight");
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back * 2), out hit,
                    1f,
                    layerMask)) 
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back * 2), Color.green,5);
                Debug.Log("Did Hit");
                {
                    Physics.IgnoreLayerCollision(8,9);
                    //Physics.IgnoreCollision(thing.GetComponent<Collider>(), GetComponent<Collider>());
                    /*if (hit.collider.tag == "BoundaryRight")
                    {
                        print("It's BoundaryRight");
                        transform.position = new Vector3(5f,oldTrans.y,oldTrans.z);
                    }
                }
            }
        }
        isSwipedRight = false;

        if (isSwipedUp)
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right * 2), out hit,
                    1f,
                    layerMask))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right * 2), Color.red, 5);
                Debug.Log("Did Hit");
                {
                    Physics.IgnoreLayerCollision(8,9);
                    /*if (hit.collider.tag == "BoundaryFar")
                    {
                        print("It's BoundaryFar");
                        transform.position = new Vector3(oldTrans.x, oldTrans.y, 5f);
                    }
                }
            }
        }
        isSwipedUp = false;

        if (isSwipedDown){
            {
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left * 2), out hit,
                        1f,
                        layerMask))
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left * 2), Color.yellow,5);
                    Debug.Log("Did Hit");
                    {
                        Physics.IgnoreLayerCollision(8,9);
                        if (hit.collider.tag == "BoundaryNear")
                        {
                            print("It's BoundaryNear");
                            transform.position = new Vector3(oldTrans.x,oldTrans.y,-5f);
                        }
                    }
                }
            }
        }
        isSwipedDown = false;
    }
    */

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "HouseMain")
        {
            Physics.gravity = new Vector3(0, -20, 0);
            canMove = false;
            //GameObject.FindWithTag("Player").GetComponent<Rigidbody>().isKinematic = true;
            print("collisionHappened");
            if (CoinsManager.coinsCount < CoinsManager.neededCount)
            {
                print(CoinsManager.coinsCount);
                print(CoinsManager.neededCount);
                resume.SetActive(true);
            }
            else if (CoinsManager.coinsCount >= CoinsManager.neededCount)
            {


                print(CoinsManager.coinsCount);
                print(CoinsManager.neededCount);
                coinsText.DecrementCoins();
                int y = SceneManager.GetActiveScene().buildIndex;
                print("Current Scene number");
                print(y);
                SceneManager.LoadScene("Lobby");
            }
            else
            {
                print(CoinsManager.coinsCount);
                print(CoinsManager.neededCount);
            }
        }
        if (collision.gameObject.tag == "Thing")
        {
            //Physics.gravity = new Vector3(0, -20, 0);
            print("collisionHappened");
            canMove = false;
            GameObject.FindWithTag("Thing").GetComponent<Rigidbody>().isKinematic = true;
            GameObject.FindWithTag("Player").GetComponent<Rigidbody>().isKinematic = true;
            //thingsBehavior.ParticlesPlay();
            restart.SetActive(true);
        }
        if (collision.gameObject.tag == "BoundaryLeft"){
            transform.position = new Vector3 (-10f,transform.position.y,transform.position.z);
            canMove = false;
            Physics.gravity = new Vector3(0, -20, 0);

        }
        if (collision.gameObject.tag == "BoundaryRight"){
            transform.position = new Vector3 (10f,transform.position.y,transform.position.z);
            canMove = false;
            Physics.gravity = new Vector3(0, -20, 0);
        }
        if (collision.gameObject.tag == "BoundaryFar"){
            transform.position = new Vector3 (transform.position.x,transform.position.y,10f);
            canMove = false;
            Physics.gravity = new Vector3(0, -20, 0);
        }
        if (collision.gameObject.tag == "BoundaryNear"){
            transform.position = new Vector3 (transform.position.x,transform.position.y,-10f);
            canMove = false;
            Physics.gravity = new Vector3(0, -20, 0);
        }
        if (collision.gameObject.tag == "BoundaryDown"){
            Destroy(this);
            restart.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            coinsSound.Play();
            Destroy(other.gameObject);
            coinsText.IncrementCoins();
            gainedCoins++;
            print("Gained coins");
            print(gainedCoins);
        }
    }
    

}
