using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float maxHealth=100f;
    // public float currentHealth;
    public HealthBar healthBar;

    public float maxSp=100f;
    // public float currentSp;
    public SpBar spBar;
    // [SerializeField] private DissolveEffect dissolveEffect;
    // [ColorUsageAttribute(true, true)]
    // [SerializeField] private Color disappearColor;
    // Start is called before the first frame update
    public void Start()
    {
        // currentHealth=maxHealth;
        FullControl.hp=maxHealth;
        FullControl.sp=maxSp;
        healthBar.SetMaxHealth(FullControl.hp);
        spBar.SetMaxSp(FullControl.sp);
        // dissolveEffect.AntiDissolve(1f, disappearColor);
    }
    public void TakeDamage(float damage){
        // currentHealth=currentHealth-damage;
        FullControl.hp=FullControl.hp-damage;
        healthBar.SetHealth(FullControl.hp);
    }
    public void ConsumeSp(float consumption){
        FullControl.sp=FullControl.sp-consumption;
        spBar.SetSp(FullControl.sp);

    }
    
}
