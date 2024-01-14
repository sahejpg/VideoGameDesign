using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingBeanController : MonoBehaviour
{
    private float _time = 0;
    private float x = 3f;
    private float force;
    Rigidbody rb;
    private bool IsGrounded;
    private float torque;

    // Start is called before the first frame update
    void Start()
    {
        //applyForce();
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        //applyForce();
        Debug.Log(IsGrounded);

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.tag == "ground")
        {
            IsGrounded = true;
        }
        IsGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        IsGrounded = false;
    }

    private void FixedUpdate()
    {
        _time += Time.deltaTime;
        //x = Random.Range(1f, 5f);
        //Debug.Log(x);
        if (_time >= x && IsGrounded)
        {
            //Debug.Log(x);
            applyForce();
            _time = 0;
            x = Random.Range(1f, 5f);
        }
        //Debug.Log(Random.Range(0f, 5f));
    }

    void applyForce()
    {
        force = Random.Range(2f, 10f);
        torque = Random.Range(5f, 20f);
        rb.AddForce(new Vector3(0, force, 0), ForceMode.Impulse);
        rb.AddTorque(new Vector3(0, 0, torque), ForceMode.Impulse);
        //Debug.Log("force");
        //applyForce();
    }
}
