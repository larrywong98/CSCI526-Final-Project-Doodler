using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI2 : MonoBehaviour
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
    private float detectRange=4f;
    public GameObject wind;
    private int attacking=0;
    private GameObject tmp1,tmp2,tmp3,tmp4;

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
        if(attacking==1){
            rb.velocity=Vector2.zero;
        }else{
            Vector3 movement=(Vector3)endPos-transform.position;
            rb.velocity=new Vector2(movement.normalized.x,movement.normalized.y)*speed;
        }
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
    private IEnumerator isAttacking(){
        attacking=1;
        // enemyState=EnemyState.idle;
        yield return new WaitForSeconds(1f);
        tmp1=Instantiate(wind, transform.position+new Vector3(1.5f,0f,transform.position.z), Quaternion.identity);
        tmp2=Instantiate(wind, transform.position+new Vector3(0f,1.5f,transform.position.z), Quaternion.Euler(0,0,90));
        tmp3=Instantiate(wind, transform.position+new Vector3(-1.5f,0f,transform.position.z), Quaternion.Euler(0,0,180));
        tmp4=Instantiate(wind, transform.position+new Vector3(0f,-1.5f,transform.position.z), Quaternion.Euler(0,0,270));
        yield return new WaitForSeconds(1f);
        // enemyState=EnemyState.chase;
        attacking=0;
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
                if(attacking==0)
                    MoveTo(playerTransform.position);
                if(Vector2.Distance(transform.position,playerTransform.position)<attackRange){
                    // player.TakeDamage(0.05f);
                    // player.ConsumeSp(0.3f);
                    if(attacking==0){
                        StartCoroutine(isAttacking());
                    }
                }else{
                    enemyState=EnemyState.chase;
                }
                break;
            case EnemyState.idle:
                // transform.position=transform.position;
                break;
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