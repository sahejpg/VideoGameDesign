using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SwooperController : MonoBehaviour
{
    public GameObject enemy;
    private Vector3 position;
    private bool moveForward = true;
    private float yDelta;

    // Start is called before the first frame update
    void Start()
    {
        position = enemy.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        yDelta = enemy.transform.position.y - position.y;

        if (moveForward)
        {
            enemy.transform.Translate(new Vector3(0, 0, 3) * Time.deltaTime);

            if (yDelta < -10)
            {
                moveForward = !moveForward;
            }
        }
        else if (!moveForward)
        {
            enemy.transform.Translate(new Vector3(0, 0, -3) * Time.deltaTime);

            if (yDelta > 10)
            {
                moveForward = !moveForward;
            }
        }
    }
}
