using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisionReporter : MonoBehaviour
{
    private void OnCollisionEnter(Collision c)
    {
        //EventManager.TriggerEvent<AudioEventManager.BombBounceEvent, Vector3>(collision.contacts);
        //foreach (ContactPoint contact in c.contacts)
        //{ 
        //}
        EventManager.TriggerEvent<BombBounceEvent, Vector3>(c.contacts[0].point);
    }
}
