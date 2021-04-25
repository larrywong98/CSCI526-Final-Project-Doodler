using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class showstore : MonoBehaviour
{
    private Transform wbc;
    public GameObject storepanel; 
    void Start(){
        wbc = GameObject.FindGameObjectWithTag("character").GetComponent<Transform>(); // 寻找玩家
    }
    void Update()
    {
        if(VAim.isAttackButtionUp==1 && wbc.position.x>54 && wbc.position.x<56 && wbc.position.y>-26 && wbc.position.y<-25){
            storepanel.SetActive(true);
        }
    }
}
