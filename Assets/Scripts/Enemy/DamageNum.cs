using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageNum : MonoBehaviour
{
    public Text damageText;
    public float lifeTimer;
    public float upSpeed;
    // public Transform target;
    // public float smoothspeed;
    void Start()
    {
        // target=GameObject.FindGameObjectWithTag("character").GetComponent<Transform>();
        Destroy(gameObject, lifeTimer);
        
    }
    void Update()
    {
        transform.position += new Vector3(0, upSpeed * Time.deltaTime, 0);
    }

    public void ShowUIDamage(float _amount){
        damageText.text = _amount.ToString();
    }
}
