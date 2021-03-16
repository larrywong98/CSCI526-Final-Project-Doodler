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
        // player=GameObject.FindGameObjectWithTag("character").transform;
        // playerTransform = player.GetComponent<Player>().transform;
        enemyState=EnemyState.roam;
        roamingPos=Roaming();
    }
    void MoveTo(Vector2 endPos){
        Vector3 movement=(Vector3)endPos-transform.position;
        // Debug.Log(movement);
        rb.velocity=new Vector2(movement.normalized.x,movement.normalized.y)*speed;
        //  Vector2 tmp=new Vector2(Vector3.Normalize(movement).x,Vector3.Normalize(movement).y);
        // rb.velocity=tmp*speed;
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
        float detectRange=5f;
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
                attackRange=2f;
                if(Vector2.Distance(transform.position,playerTransform.position)<attackRange){
                    enemyState=EnemyState.attack;
                }
                break;
            case EnemyState.attack:
                MoveTo(playerTransform.position);
                attackRange=2f;
                if(Vector2.Distance(transform.position,playerTransform.position)<attackRange){
                    player.TakeDamage(1f);
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
        if(player.currentHealth==0){
            Loader.Load(Loader.Scene.MainMenu);
        }
    }
}