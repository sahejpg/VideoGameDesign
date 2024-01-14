using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyFollow : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform player;
    public Boss_Script boss_Script;
    private float distanceBetweenTarget;
    private float fireCount = 0f;
    private int enemyDamage = 10;

    [SerializeField] private float fireRate = 4f;
    [SerializeField] private Transform[] projectileSpawnPoint;
    [SerializeField] private GameObject projectilePrefab;

    public float AliveCount = 1;
    public AudioSource shot;
    public AudioSource die;
    public GameObject floatingText;
    private bool alreadyShot = false;

    // private void Start() {
    //     enemy = GetComponent<NavMeshAgent>();
    // }

    private void Update() {
        distanceBetweenTarget = Vector3.Distance(player.position, enemy.transform.position);
        if (distanceBetweenTarget < 20)
        {
            enemy.SetDestination(player.position);
            // put if collision here? make the attacks into their own methods?
            if (enemy.tag == "Boss1" || enemy.tag == "Boss3") {
                if (enemy.tag == "Boss1") {
                    GetComponent<NavMeshAgent>().speed = 4f;
                }
                GetComponent<Animator>().SetTrigger("Attack");
            }
            if (distanceBetweenTarget < 5f && enemy.tag == "Boss1") {
                GetComponent<NavMeshAgent>().speed = 4.5f;
                GetComponent<Animator>().SetTrigger("Roll");
            }
            else if (enemy.tag == "Boss2" || enemy.tag == "Boss3") {
                if (distanceBetweenTarget <= 20) {
                    if (enemy.tag == "Boss3") {
                        GetComponent<Animator>().SetTrigger("Idle");
                    }
                    
                    if (fireCount <= 0f) {
                        foreach(Transform spawnPoints in projectileSpawnPoint)
                        {
                            Instantiate(projectilePrefab, spawnPoints.position, transform.rotation);
                        }

                        if (enemy.tag == "Boss2" || enemy.tag == "Boss3") {
                            fireCount = 2f/fireRate;    // shooting twice within 1 second
                        }
                    }
                    fireCount -= Time.deltaTime;
        
                }
            }
        } else if (distanceBetweenTarget > 20 && (enemy.tag == "Boss1" || enemy.tag == "Boss2")) {
            GetComponent<Animator>().SetTrigger("Idle");
        }

        // make boss 2 look in character position
        if (enemy.tag == "Boss2") {
            Vector3 targetDirection = player.position - transform.position;
            float singleStep = GetComponent<NavMeshAgent>().speed * Time.deltaTime;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
            Debug.DrawRay(transform.position, newDirection, Color.red);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }

    private void OnCollisionExit(Collision collision) {
        if (collision.gameObject.tag == "playerShot") {
            Debug.Log("collided");
            Shot();
            //Destroy(collision.gameObject);
            collision.gameObject.tag = "destroyAcorn";
            Destroy(collision.gameObject);
        }
    }

    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.tag == "playerShot" && alreadyShot == false)
    //    {
    //        Debug.Log("collided");
    //        Shot();
    //        alreadyShot = true;
    //        //Destroy(collision.gameObject);
    //        collision.gameObject.tag = "destroyAcorn";
    //    }
    //}

    public void Shot() {
        if (boss_Script.currHealth < 10) {
            GetComponent<Animator>().SetTrigger("Die");
            die.Play();
            Destroy(enemy.gameObject);
            // Debug.Log("Dead");
            AliveCount--;
        } else {
            boss_Script.currHealth -= enemyDamage;
            Debug.Log(boss_Script.currHealth);
            GetComponent<Animator>().SetTrigger("Shot");
            ShowText();
            shot.Play();
        }
    }

    public void increaseEnemyDamage(int x)
    {
        enemyDamage += x;
    }

    private void ShowText() {
        Instantiate(floatingText, transform.position, Quaternion.identity, transform);
    }

}
