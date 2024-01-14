using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_Script : MonoBehaviour
{
    public int maxHealth;
    public int currHealth;

    public Slider healthBar;

    private void Awake() {
        healthBar.maxValue = maxHealth;
    }

    private void Update() {
        healthBar.value = currHealth;
    }
}
