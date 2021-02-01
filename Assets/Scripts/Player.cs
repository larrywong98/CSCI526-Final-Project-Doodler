using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float maxHealth=100;
    public float currentHealth;
    public HealthBar healthBar;
    // Start is called before the first frame update
    public void Start()
    {
        currentHealth=maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    public void TakeDamage(float damage){
        currentHealth=currentHealth-damage;
        healthBar.SetHealth(currentHealth);
    }
    
}
