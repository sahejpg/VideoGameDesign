using UnityEngine;

// Include the namespace required to use Unity UI and Input System
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using System.Collections;


public class PlayerController : MonoBehaviour
{


    // Create public variables for player speed, and for the Text UI game objects
    public float speed = 7;
    public float jumpAmount;
    public float jumpCoolDown;
    public float turnSpeed = 120;


    private float maxHealth = 100;
    private float currHealth;


    public Text countText;
    public GameObject winTextObject;
    public GameObject self;
    public Animator squirrelAnimator;


    public GameObject tree_1;
    public GameObject tree_2;
    public GameObject tree_3;
    public GameObject tree_1_leaves;
    public GameObject tree_2_leaves;
    public GameObject tree_3_leaves;
    public GameObject bossText1;
    public GameObject bossText2;
    public GameObject bossText3;
    public GameObject scrollTextButton;
    public GameObject floor;


    public Slider healthBar;
    public AudioSource acornAudio;
    public AudioSource poopAudio;
    public AudioSource acornShoot;
    public AudioSource ouch;
    public AudioSource crateCrash;


    // shooting acorn stuff
    public Transform projectileSpawnPoint;
    public GameObject acornBullet;


    // Win and lose Screens
    public CanvasGroup loseScreen;
    public CanvasGroup winScreen;
    public EnemyFollow EnemyFollow;


    // Timer in fixed update frames. Update the first number for minutes.
    private int timeRemaining = 12 * 60 * 50;
    private bool timerRunning = true;
    public Text timerText;


    private int wait = 0;
    private enum TREE
    {
        Ground,
        Tree_1,
        Tree_2,
        Tree_3
    }
    private TREE tree_value = TREE.Ground;
    private bool switchZY = false;


    private float movementX;
    private float movementY;
    private float movementZ;


    private Rigidbody rb;
    private int count = 0;


    private float timeSinceJump;
    private Animator anim;
    private Rigidbody rbody;
    private CharacterInputController cinput;


    // Used to interpolate all things motion on the tree
    private float rotationAngleOnTree;


    //Used to keep track of which bosses the player has seen
    private bool facedBoss1 = false;
    private bool facedBoss2 = false;
    private bool facedBoss3 = false;


    void Awake()
    {
        anim = GetComponent<Animator>();


        if (anim == null)
            Debug.Log("Animator could not be found");


        rb = GetComponent<Rigidbody>();


        if (rb == null)
            Debug.Log("Rigid body could not be found");


        cinput = GetComponent<CharacterInputController>();


        if (cinput == null)
            Debug.Log("CharacterInputController could not be found");


    }


    // At the start of the game..
    void Start()
    {
        // Assign the Rigidbody component to our private rb variable
        rb = GetComponent<Rigidbody>();


        // set spawn point
        transform.position = new Vector3(-143.26f, 4, 44.72f);
        transform.Rotate(0, -90f, 0);


        // Set the count to zero
        count = 0;
        // SetCountText();
        countText.text = "Count: " + count.ToString();
        winTextObject.SetActive(false);
        bossText1.SetActive(false);
        bossText2.SetActive(false);
        bossText3.SetActive(false);
        scrollTextButton.SetActive(false);


        // Set timeSinceJump to Cool Down time so jump can happen at start
        timeSinceJump = jumpCoolDown;


        // set health bar to max value
        healthBar.maxValue = maxHealth;
        currHealth = maxHealth;


        // loseScreen.alpha = 0f;
        loseScreen.gameObject.SetActive(false);

    }


    void OnCollisionEnter(Collision collision)
    {
        if (wait == 0)
        {
            if (collision.gameObject == tree_1 && tree_value != TREE.Tree_1)
            {
                tree_value = TREE.Tree_1;


                float tree_pos_x = 0f;
                float tree_pos_z = 0f;
                float tree_diameter = 30f;
                float squirrel_to_tree_pos_x = rb.position.x - tree_pos_x;
                float squirrel_to_tree_pos_z = rb.position.z - tree_pos_z;


                rotationAngleOnTree = Mathf.Atan(squirrel_to_tree_pos_x / squirrel_to_tree_pos_z) * (180 / Mathf.PI);
            }
            else if (collision.gameObject == tree_2 && tree_value != TREE.Tree_2)
            {
                tree_value = TREE.Tree_2;


                float tree_pos_x = 30f;
                float tree_pos_z = 50f;
                float tree_diameter = 30f;
                float squirrel_to_tree_pos_x = rb.position.x - tree_pos_x;
                float squirrel_to_tree_pos_z = rb.position.z - tree_pos_z;


                rotationAngleOnTree = Mathf.Atan(squirrel_to_tree_pos_x / squirrel_to_tree_pos_z) * (180 / Mathf.PI);
                Debug.Log(rotationAngleOnTree);
            }
            else if (collision.gameObject == tree_3 && tree_value != TREE.Tree_3)
            {
                tree_value = TREE.Tree_3;


                float tree_pos_x = 50f;
                float tree_pos_z = -50f;
                float tree_diameter = 30f;
                float squirrel_to_tree_pos_x = rb.position.x - tree_pos_x;
                float squirrel_to_tree_pos_z = rb.position.z - tree_pos_z;


                rotationAngleOnTree = Mathf.Atan(squirrel_to_tree_pos_x / squirrel_to_tree_pos_z) * (180 / Mathf.PI);
                Debug.Log(rotationAngleOnTree);
            }
        }


        if ((collision.gameObject == tree_1_leaves || collision.gameObject == tree_2_leaves || collision.gameObject == tree_3_leaves) && tree_value != TREE.Ground)
        {
            tree_value = TREE.Ground;
            wait = 0;
            Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, 0, 0));
            rb.MoveRotation(deltaRotation);
            rb.MovePosition(rb.position + new Vector3(0, 5, 0));


            //logic to display boss text only the first time on top of the tree
            if (collision.gameObject == tree_1_leaves && !facedBoss1)
            {
                facedBoss1 = true;
                Debug.Log("This is the first boss");
                StartCoroutine(waitForLeaves(1));
            }


            if (collision.gameObject == tree_2_leaves && !facedBoss2)
            {
                facedBoss2 = true;
                Debug.Log("This is the second boss");
                StartCoroutine(waitForLeaves(2));
            }


            if (collision.gameObject == tree_3_leaves && !facedBoss3)
            {
                facedBoss3 = true;
                Debug.Log("This is the third boss");
                StartCoroutine(waitForLeaves(3));
            }
        }


        if (collision.gameObject == floor && tree_value != TREE.Ground)
        {
            tree_value = TREE.Ground;
            wait = 10;
            Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, 0, 0));
            rb.MoveRotation(deltaRotation);
        }
        Debug.Log("Entered collision with " + collision.gameObject.name);


        if (collision.gameObject.tag == "enemyShot" || collision.gameObject.tag == "Boss1" || collision.gameObject.tag == "Boss3")
        {
            takeDamage();
        }

        if (collision.gameObject.tag == "crates") {
            crateCrash.Play();
        }
    }


    IEnumerator waitForLeaves(int num)
    {
        yield return new WaitForSeconds(1);
        scrollTextButton.SetActive(true);


        if (num == 1)
        {
            bossText1.SetActive(true);
        }


        if (num == 2)
        {
            bossText2.SetActive(true);
        }


        if (num == 3)
        {
            bossText3.SetActive(true);
        }


        Time.timeScale = 0f;
    }


    void Update()
    {


        if (Input.GetKeyDown(KeyCode.T) && count > 0)
        {
            Instantiate(acornBullet, projectileSpawnPoint.position, transform.rotation);
            count -= 1;
        }
        else if (Input.GetKeyDown(KeyCode.T) && count == 0)
        {
            poopAudio.Play();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)
            || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            squirrelAnimator.SetBool("isMoving", true);
            squirrelAnimator.SetFloat("speed", 1);
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow)
            || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            squirrelAnimator.SetBool("isMoving", false);
            squirrelAnimator.SetFloat("speed", 0);
            // squirrelAnimator.Play("Squirrel_idle");
            squirrelAnimator.CrossFadeInFixedTime("Squirrel_idle", 0.3f);
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            squirrelAnimator.SetBool("jump", true);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            squirrelAnimator.SetBool("jump", false);
        }


        // else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow)
        //     || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        // {
        //     squirrelAnimator.enabled = true;
        //     // new WaitForSeconds(1.0f);
        //     squirrelAnimator.SetFloat("speed", 1);
        //     squirrelAnimator.Play("SquirrelCrawl");          
        // } else if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.UpArrow)
        //     || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        // {
        //     // new WaitForSeconds(5.0f);
        //     squirrelAnimator.SetFloat("speed", 0);
        //     squirrelAnimator.Play("Squirrel_idle");  


        // }




        countText.text = "Count: " + count.ToString();
        if (timeRemaining / 50 % 60 < 10) {
            timerText.text = "Time Remaining: " + (timeRemaining / 60 / 50) + ":0" + (timeRemaining / 50 % 60);
        } else {
            timerText.text = "Time Remaining: " + (timeRemaining / 50 / 60) + ":" + (timeRemaining / 50 % 60);
        }


        // check whether win screen or lose screen
        if (EnemyFollow.AliveCount == 0)
        {
            winScreen.gameObject.SetActive(true);
            winScreen.interactable = true;
            winScreen.blocksRaycasts = true;
            winScreen.alpha = 1f;
            Time.timeScale = 0f;
        }


    }


    void FixedUpdate()
    {
        float inputForward = 0f;
        float inputTurn = 0f;


        if (cinput.enabled)
        {
            inputForward = cinput.Forward;
            inputTurn = cinput.Turn;
        }


        if (tree_value == TREE.Ground)
        {
            // Switch turn around if going backwards
            if (inputForward < 0f)
                inputTurn = -inputTurn;


            // Normal Movement
            rb.MovePosition(rb.position + this.transform.forward * inputForward * Time.deltaTime * speed);
            rb.MoveRotation(rb.rotation * Quaternion.AngleAxis(inputTurn * Time.deltaTime * turnSpeed, Vector3.up));


            anim.SetFloat("vely", inputForward);


            rb.useGravity = true;


        }
        else
        {
            float tree_pos_x = 0f;
            float tree_pos_z = 0f;
            float tree_diameter = 10f;


            // Sets values for which tree the squirrel is currenlty on
            switch (tree_value)
            {
                case TREE.Tree_1:
                    tree_pos_x = 0f;
                    tree_pos_z = 0f;
                    tree_diameter = 30f;
                    break;
                case TREE.Tree_2:
                    tree_pos_x = 30f;
                    tree_pos_z = 50f;
                    tree_diameter = 30f;
                    break;
                case TREE.Tree_3:
                    tree_pos_x = 50f;
                    tree_pos_z = -50f;
                    tree_diameter = 30f;
                    break;
                default:
                    break;
            }


            rb.useGravity = false;
            rb.velocity = new Vector3(0, 0, 0);
            rb.MovePosition(rb.position + new Vector3(0, 1, 0) * inputForward * Time.deltaTime * speed);


            // Make rotating around the tree change with input left and right
            rotationAngleOnTree = rotationAngleOnTree - inputTurn;


            Quaternion deltaRotation = Quaternion.Euler(new Vector3(-90, rotationAngleOnTree + 180, 0));
            rb.MoveRotation(deltaRotation);


            // Pushes squirrel to tree / sets position based on angle of attachment
            Vector3 moveToTree = new Vector3(Mathf.Sin((rotationAngleOnTree * Mathf.PI) / 180f) * tree_diameter / 2f + tree_pos_x, rb.position.y, Mathf.Cos((rotationAngleOnTree * Mathf.PI) / 180f) * tree_diameter / 2f + tree_pos_z);
            rb.MovePosition(moveToTree);
        }


        if (wait > 0)
        {
            wait -= 1;
        }


        timeSinceJump += Time.deltaTime;

        if (timerRunning) {
            timeRemaining -= 1;
        }

        if (timeRemaining == 0) {
            timerRunning = false;
            currHealth = 0;
            takeDamage();
        }
    }


    // void SetCountText()
    // {
    //     countText.text = "Count: " + count.ToString();
    //     // if(count >= 12)
    //     // {
    //     //     winTextObject.SetActive(true);
    //     // }
    // }


    void OnTriggerEnter(Collider other)
    {
        // ..and if the GameObject you intersect has the tag 'Pick Up' assigned to it..
        if (other.gameObject.CompareTag("Pickup"))
        {
            acornAudio.Play();
            other.gameObject.SetActive(false);


            // Add one to the score variable 'count'
            count = count + 1;


            // SetCountText();


            print(count);


            // Run the 'SetCountText()' function (see below)
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            takeDamage();
        }
        if (other.gameObject.CompareTag("FasterEnemy"))
        {
            takeDamage();
        }
    }


    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();


        movementX = v.x;
        movementY = v.y;


        // bool jump = value.Get<
    }


    void OnJump(InputValue jumpValue)
    {
        if (timeSinceJump >= jumpCoolDown && jumpValue.isPressed)
        {
            rb.velocity += new Vector3(0f, jumpAmount, 0f);
            timeSinceJump = 0;
        }
    }


    void takeDamage()
    {
        if (currHealth < 10)
        {
            healthBar.value = 0;
            loseScreen.gameObject.SetActive(true);
            loseScreen.interactable = true;
            loseScreen.blocksRaycasts = true;
            loseScreen.alpha = 1f;
            Time.timeScale = 0f;
        }
        else
        {
            currHealth -= 10;
            healthBar.value = currHealth;
            loseScreen.interactable = false;
            loseScreen.blocksRaycasts = false;
            loseScreen.alpha = 0f;
            Time.timeScale = 1f;
            ouch.Play();
        }
    }


    public int GetCount()
    {
        return count;
    }


    public void SetCount(int x)
    {
        count = x;
    }


    public void IncreaseCurrHealth(int x)
    {
        currHealth += x;
        healthBar.value = currHealth;
    }


}
