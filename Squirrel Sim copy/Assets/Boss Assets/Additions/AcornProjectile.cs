using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcornProjectile : MonoBehaviour
{
    public Rigidbody rb;
    private float launchForce = 50f;
    private float destroyAfter = 20f;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.forward * launchForce;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, destroyAfter);
    }
}
