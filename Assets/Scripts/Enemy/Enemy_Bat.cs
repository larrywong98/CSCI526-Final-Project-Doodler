using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bat : MonoBehaviour
{

    [SerializeField] private float moveSpeed;

    private Transform target;

    [SerializeField] private float maxHp;
    [SerializeField] private Rigidbody2D rb;

    public float hp;

    [Header("Hurt")]
    private SpriteRenderer sp; // 材质
    public float hurtLength; // 被击中颜色变化的时间
    private float hurtCounter; // 被击中的计数器


    public bool isAttacked;
    public GameObject explosionEffect;


    // Start is called before the first frame update
    void Start()
    {

        hp = maxHp; // 初始化生命值
        target = GameObject.FindGameObjectWithTag("character").GetComponent<Transform>(); // 寻找玩家
        sp = GetComponent<SpriteRenderer>(); // 获取材质
        
    }

    // Update is called once per frame
    void Update()
    {
        
        FollowPlayer();

        if(hurtCounter <= 0){
            sp.material.SetFloat("_FlashAmount", 0); // 若计数器为0则不变动
        }else{
            hurtCounter -= Time.deltaTime; // 若大于0则每帧减少
        }

    }


    private void FollowPlayer(){
        // transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);  
        Vector3 movement=(Vector3)target.position-transform.position;
        rb.velocity=new Vector2(movement.x,movement.y)*moveSpeed;
        // rb.velocity=new Vector2(VJoystick.joystickpos.x,VJoystick.joystickpos.y)*speed;
    }


    public void TakenDamage(float _amount){

        isAttacked = true; // only be hitted once per slash
        StartCoroutine(isAttackCo());
        hp -= _amount; // 扣血

        HurtShader(); // 伤害贴图
        // Instantiate(explosionEffect, transform.position, Quaternion.identity);
        if (hp <= 0){
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            MissionStatus.killed[0]=MissionStatus.killed[0]+1;
            MissionStatus.CheckComplete();
        } // 血条为0则销毁            
    }



    private void HurtShader(){

        sp.material.SetFloat("_FlashAmount", 1);
        hurtCounter = hurtLength;
        
    }

    IEnumerator isAttackCo(){
        yield return new WaitForSeconds(0.2f);
        isAttacked = false;
    }
}
