using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class fire : MonoBehaviour
{
    public Button m_Btn;
    public GameObject target;
    private PlayerController playerController;
    void Start(){
        m_Btn.onClick.AddListener(Shoot);
        playerController=target.GetComponent<PlayerController>();
    }

    void Shoot()
    { 
        playerController.AimAndShoot(1);
        
    }
}
