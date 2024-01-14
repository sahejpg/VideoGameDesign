using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCharacter : MonoBehaviour
{
    public Dialogue dialogue;
    public AudioSource poof;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (dialogue.passIn == false) {
            Destroy(gameObject, 1);
            poof.Play();
        }
    }
}
