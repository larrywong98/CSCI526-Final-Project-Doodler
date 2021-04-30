using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using System;
// using Pathfinding;

public class EnemyAI_1 : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 roamingPos;
    [SerializeField]private Transform playerTransform;
    // public HealthBar healthBar;
    private EnemyState enemyState;
    public Player player;
    private float attackRange=2f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    private float detectRange=5f;

    // public Animator fade;
    // private float transitionTime=1f;

    public enum EnemyState
    {
        idle,
        roam,
        attack,
        chase
    }
    void Start()
    {
        startPos=transform.position;
        enemyState=EnemyState.roam;
        playerTransform=GameObject.FindGameObjectWithTag("character").GetComponent<Transform>(); 
        player=GameObject.FindGameObjectWithTag("character").GetComponent<Player>(); 
        roamingPos=Roaming();
    }
    void MoveTo(Vector2 endPos){
        Vector3 movement=(Vector3)endPos-transform.position;
        rb.velocity=new Vector2(movement.normalized.x,movement.normalized.y)*speed;
    }
    public Vector3 RandomDirection(){
        return new Vector3(UnityEngine.Random.Range(-1f,1f),
                           UnityEngine.Random.Range(-1f,1f),
                           transform.position.z).normalized;
    }
    private Vector3 Roaming(){
        return startPos+RandomDirection() * Random.Range(1f,10f);
    }

    public void FindPlayer(){
        
        // Debug.Log(Vector2.Distance(transform.position,playerTransform.position));
        if(Vector2.Distance(transform.position,playerTransform.position)<detectRange){
            enemyState=EnemyState.chase;
        }
    }

    private void Update()
    {
        // Debug.Log(enemyState);
        switch (enemyState)
        {
            case EnemyState.roam:
                MoveTo(roamingPos);
                float closedistance=5f;
                if(Vector2.Distance(transform.position,roamingPos)<closedistance){
                    roamingPos=Roaming();
                }
                FindPlayer();
                break;
                
            case EnemyState.chase:
                MoveTo(playerTransform.position);
                if(Vector2.Distance(transform.position,playerTransform.position)<attackRange){
                    enemyState=EnemyState.attack;
                }
                if(Vector2.Distance(transform.position,playerTransform.position)>detectRange){
                    enemyState=EnemyState.roam;
                }
                break;
            case EnemyState.attack:
                MoveTo(playerTransform.position);
                if(Vector2.Distance(transform.position,playerTransform.position)<attackRange){
                    player.TakeDamage(0.05f);
                    // player.ConsumeSp(0.3f);
                }else{
                    enemyState=EnemyState.chase;
                }
                break;
            // case EnemyState.idle:
            //     transform.position=transform.position;
            //     break;
            default:
                break;
        }
        // Debug.Log(player.currentHealth);
        // if(player.currentHealth<=0){
        //     fade.SetTrigger("out");
        //     StartCoroutine(waitLoad());
        // }
    }
    
}