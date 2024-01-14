using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SweeperController : MonoBehaviour
{
    public GameObject enemy;
    private Vector3 position;
    private bool moveForward = true;
    private float xDelta;

    // Start is called before the first frame update
    void Start()
    {
        position = enemy.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        xDelta = enemy.transform.position.x - position.x;

        if (moveForward)
        {
            enemy.transform.Translate(new Vector3(3, 0, 0) * Time.deltaTime);

            if (xDelta > 10)
            {
                moveForward = !moveForward;
            }
        }
        else if (!moveForward)
        {
            enemy.transform.Translate(new Vector3(-3, 0, 0) * Time.deltaTime);

            if (xDelta < -10)
            {
                moveForward = !moveForward;
            }
        }
    }
}
