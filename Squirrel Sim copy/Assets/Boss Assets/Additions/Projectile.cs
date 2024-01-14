using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // [SerializeField] private Rigidbody rigidbody;
    // [SerializeField] private float launchForce = 50f;
    public float speed;
    private Transform player;
    private Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        // rigidbody.velocity = transform.forward * launchForce;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = player.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (Vector3.Distance(target, transform.position) == 0) {
            Destroy(gameObject);
        } 
    }
}
