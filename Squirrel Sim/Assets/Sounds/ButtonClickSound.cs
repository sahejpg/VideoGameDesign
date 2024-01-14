using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickSound : MonoBehaviour
{
    public AudioSource click;
    
    public void clickSound() {
        click.Play();
        print("I played!!!");
    }
}
