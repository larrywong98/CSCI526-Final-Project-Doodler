using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Boss : MonoBehaviour
{
    // [SerializeField] private float moveSpeed;
    private Transform target;
    [SerializeField] private float maxHp;
    [SerializeField] private Rigidbody2D rb;
    public float hp;
    public Animator fade;
    [Header("Hurt")]
    private SpriteRenderer sp; // 材质
    public float hurtLength; // 被击中颜色变化的时间
    private float hurtCounter; // 被击中的计数器
    public bool isAttacked;
    public GameObject explosionEffect;

    Vector3 lastPostion;
    Vector3 localVelocity;
    public GameObject winVideo;
    public GameObject enemies;
    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp; // 初始化生命值
        target = GameObject.FindGameObjectWithTag("character").GetComponent<Transform>(); // 寻找玩家
        sp = GetComponent<SpriteRenderer>(); // 获取材质
        FullControl.id=9;
        lastPostion = transform.position;

    }
    // Update is called once per frame
    void Update()
    {
        // FollowPlayer();
        if(hurtCounter <= 0){
            sp.material.SetFloat("_FlashAmount", 0); // 若计数器为0则不变动
        }else{
            hurtCounter -= Time.deltaTime; // 若大于0则每帧减少
        }
        // Flip at each frame
        Flip();
        lastPostion = transform.position;

    }
    // private void FollowPlayer(){
    //     // transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);  
    //     Vector3 movement=(Vector3)target.position-transform.position;
    //     rb.velocity=new Vector2(movement.x,movement.y)*moveSpeed;
    //     // rb.velocity=new Vector2(VJoystick.joystickpos.x,VJoystick.joystickpos.y)*speed;
    // }
    public void TakenDamage(float _amount){
        isAttacked = true; // only be hitted once per slash
        StartCoroutine(isAttackCo());
        hp -= _amount; // 扣血
        HurtShader(); // 伤害贴图
        // Instantiate(explosionEffect, transform.position, Quaternion.identity);
        // Debug.Log(hp);
        if (hp <= 0){
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            FullControl.deadboss=FullControl.deadboss+1;
            // fade.SetTrigger("out");
            
            winVideo.SetActive(true);
            enemies.SetActive(false);
            
            // Debug.Log(FullControl.deadGreenBacteria);
            // MissionStatus.CheckComplete();
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

    private void Flip()
    {
        localVelocity = target.position-transform.position;
        if(localVelocity.x > 0){
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if(localVelocity.x < 0){
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

    }
}
