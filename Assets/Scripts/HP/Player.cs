using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float maxHealth=100f;
    public float currentHealth;
    public HealthBar healthBar;
    // [SerializeField] private DissolveEffect dissolveEffect;
    // [ColorUsageAttribute(true, true)]
    // [SerializeField] private Color disappearColor;
    // Start is called before the first frame update
    public void Start()
    {
        currentHealth=maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        // dissolveEffect.AntiDissolve(1f, disappearColor);
    }
    public void TakeDamage(float damage){
        currentHealth=currentHealth-damage;
        healthBar.SetHealth(currentHealth);
    }
    
}
