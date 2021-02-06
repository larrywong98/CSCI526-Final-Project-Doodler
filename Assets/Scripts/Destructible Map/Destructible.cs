using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    // Start is called before the first frame update
    public float health;
    public GameObject destoryEffect;
    void Update(){
        if (health<=0){
            GameObject effectTmp=Instantiate(destoryEffect,transform.position,Quaternion.identity);
            Destroy(gameObject);
            Destroy(effectTmp,2f);
        }
    }
}
