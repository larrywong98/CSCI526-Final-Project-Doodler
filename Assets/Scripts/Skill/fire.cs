using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class fire : MonoBehaviour
{
    // public Animator animator;
    // public int playerId = 0;
    // public GameObject crossHair;
    public GameObject arrowPrefab;
    public Transform playerTransform;
    public Vector2 shootingDirection;
    public Transform enemyTransform;

    public Button m_Btn;
    public GameObject target;
    private PlayerController playerController;
    void Start(){
        m_Btn.onClick.AddListener(Shoot);
        // playerController=target.GetComponent<PlayerController>();
        // playerTransform=GameObject.FindGameObjectWithTag("character").GetComponent<Transform>().transform;
    }

    void Shoot()
    { 
        // playerController.AimAndShoot(1);
        shootingDirection= enemyTransform.position-playerTransform.position;
        GameObject arrow = Instantiate(arrowPrefab, playerTransform.position+new Vector3(0f,1f,0f), Quaternion.identity);
        // arrow.GetComponent<Rigidbody2D>().velocity = shootingDirection * 10.0f; // set arrow velocity
        arrow.transform.Rotate(0.0f, 0.0f, Mathf.Atan2(-shootingDirection.y, -shootingDirection.x) * Mathf.Rad2Deg);
        // Destroy(arrow, 2.0f);
        
    }
}
