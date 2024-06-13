using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody player;
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
    public GameObject restart;
    public GameObject resume;
    public Player playGameObj;
    public CoinsManager coinsText;
    public CoinsSkinManager skinsText;
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
    public int gainedSkinsCoins;
    public AudioSource coinsSound;
    public MusicSettings musicSettings;
    public bool isOn;
    public SoundsSettings soundsSettings;
    public bool isOnSounds;
    public ChangeHeroes changeHeroes;
    public GameObject enoughText;
    public GameObject notEnoughText;
    public GameObject endLevelWindow;


    void Start()
    {
        endLevelWindow = GameObject.Find("/CoinsEnough");
        coinsSound = GameObject.Find("Sounds").GetComponent<AudioSource>();
        playGameObj = GetComponent<Player>();
        player = GetComponent<Rigidbody>();
        restart = GameObject.FindWithTag("Restart");
        resume = GameObject.Find("/CoinsNotEnough");
        restart.SetActive(false);
        resume.SetActive(false);
        endLevelWindow.SetActive(false);
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
        if(resume.activeInHierarchy)
        {
            if(CoinsManager.coinsCount >= CoinsManager.neededCount)
            {
                coinsToNeededCompare();
            }
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "HouseMain")
        {
            coinsToNeededCompare();
        }
        if (collision.gameObject.tag == "Thing")
        {
            Destroy(collision.gameObject);
            print("collisionHappened");
            canMove = false;
            //GameObject.FindWithTag("Thing").GetComponent<Rigidbody>().isKinematic = true;
            GameObject.FindWithTag("Player").GetComponent<Rigidbody>().isKinematic = true;
            //thingsBehavior.ParticlesPlay();
            restart.SetActive(true);
        }
        if (collision.gameObject.tag == "BoundaryLeft"){
            canMove = false;
            transform.position = new Vector3 (-10f,transform.position.y,transform.position.z);
            Physics.gravity = new Vector3(0, -20, 0);

        }
        if (collision.gameObject.tag == "BoundaryRight"){
            canMove = false;
            transform.position = new Vector3 (10f,transform.position.y,transform.position.z);

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
            GameObject.FindWithTag("Player").GetComponent<Rigidbody>().isKinematic = true;
            restart.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ticket")
        {
            coinsSound.Play();
            Destroy(other.gameObject);
            coinsText.IncrementCoins();
            gainedCoins++;
            print("Gained tickets");
            print(gainedCoins);
        }
        if (other.gameObject.tag == "Coin")
        {
            coinsSound.Play();
            Destroy(other.gameObject);
            skinsText.IncrementSkinsCoins();
            gainedSkinsCoins++;
            print("Gained coins");
            print(gainedSkinsCoins);
        }
    }

    void coinsToNeededCompare(){
        Physics.gravity = new Vector3(0, -20, 0);
        canMove = false;
        //GameObject.FindWithTag("Player").GetComponent<Rigidbody>().isKinematic = true;
        print("collisionHappened");
        if (CoinsManager.coinsCount < CoinsManager.neededCount)
        {
            resume.SetActive(true);
            endLevelWindow.SetActive(false);
            print(CoinsManager.coinsCount);
            print(CoinsManager.neededCount);
        }
        else if (CoinsManager.coinsCount >= CoinsManager.neededCount)
        {
            resume.SetActive(false);
            endLevelWindow.SetActive(true);
            print(CoinsManager.coinsCount);
            print(CoinsManager.neededCount);
            canMove = false;
            GameObject.FindWithTag("Player").GetComponent<Rigidbody>().isKinematic = true;
            coinsText.DecrementCoins();
            int y = SceneManager.GetActiveScene().buildIndex;
            print("Current Scene number");
            print(y);
            PlayerPrefs.SetInt("LevelPassedNumber", y);

        }
        else
        {
            print(CoinsManager.coinsCount);
            print(CoinsManager.neededCount);
        }
    }

}
