using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float speed = 10;
    //public GameObject self;
    public GameObject curr_tree;
    //public GameObject tree_2;
    //public GameObject tree_3;
    private enum TREE
    {
        NULL,
        Tree_1,
        Tree_2,
        Tree_3
    }
    private TREE tree_value = TREE.Tree_1;
    public Rigidbody rb;
    private Animator anim;
    private float rotationAngleOnTree;
    //float bird_pos_x;
    float bird_pos_z;
    float inputTurn;
    float tree_pos_x = 0f;
    float tree_pos_z = 0f;

    private void Awake()
    {
        anim = GetComponent<Animator>();

        rb = GetComponent<Rigidbody>();
        inputTurn = 0.5f;
        if (rb.gameObject.CompareTag("Enemy") == false)
        {
            //rb = GameObject.Find("fasterBlueJay").GetComponent<Rigidbody>();
            inputTurn = 2f;
        }

        if (rb == null)
            Debug.Log("Rigid body could not be found");
    }
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        bird_pos_z = rb.position.z;

        if (curr_tree.gameObject.CompareTag("Tree1"))
        {
            //Debug.Log("curr tree");
            tree_pos_x = 0f;
            tree_pos_z = 0f;
            //float tree_diameter = 30f;
            float bird_to_tree_pos_x = rb.position.x - tree_pos_x;
            float bird_to_tree_pos_z = rb.position.z - tree_pos_z;

            rotationAngleOnTree = Mathf.Atan(bird_to_tree_pos_x / bird_to_tree_pos_z) * (180 / Mathf.PI);
        }
        else if (curr_tree.gameObject.CompareTag("Tree2"))
        {
            tree_pos_x = 30f;
            tree_pos_z = 50f;
            //float tree_diameter = 30f;
            float bird_to_tree_pos_x = rb.position.x - tree_pos_x;
            float bird_to_tree_pos_z = rb.position.z - tree_pos_z;

            rotationAngleOnTree = Mathf.Atan(bird_to_tree_pos_x / bird_to_tree_pos_z) * (180 / Mathf.PI);
            //Debug.Log(rotationAngleOnTree);
        }
        else if (curr_tree.gameObject.CompareTag("Tree3"))
        {
            tree_pos_x = 50f;
            tree_pos_z = -50f;
            //float tree_diameter = 30f;
            float bird_to_tree_pos_x = rb.position.x - tree_pos_x;
            float bird_to_tree_pos_z = rb.position.z - tree_pos_z;

            rotationAngleOnTree = Mathf.Atan(bird_to_tree_pos_x / bird_to_tree_pos_z) * (180 / Mathf.PI);
            //Debug.Log(rotationAngleOnTree);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        //float inputForward = 0f;
        //float inputTurn = 0.5f;
        //float tree_pos_x = 0f;
        //float tree_pos_z = 0f;
        float tree_diameter = 30f;

        rb.useGravity = false;

        rotationAngleOnTree = rotationAngleOnTree - inputTurn;

        Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, rotationAngleOnTree + 245, -90));
        rb.MoveRotation(deltaRotation);
        Vector3 moveToTree = new Vector3(Mathf.Sin((rotationAngleOnTree * Mathf.PI) / 180f) * tree_diameter / 2f + tree_pos_x, rb.position.y, Mathf.Cos((rotationAngleOnTree * Mathf.PI) / 180f) * tree_diameter / 2f + tree_pos_z);
        rb.MovePosition(moveToTree);
        //Quaternion birdRotation = Quaternion.Euler(new Vector3(0f, -90f, 90f));
        //rb.MoveRotation(birdRotation);
    }
    void OnTriggerEnter(Collider other)
    {

    }

    void OnTriggerExit(Collider other)
    {

    }
}
