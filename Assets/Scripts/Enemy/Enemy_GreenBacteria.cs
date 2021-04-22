using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_GreenBacteria : MonoBehaviour
{
    // [SerializeField] private float moveSpeed;
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
    public GameObject oxygenObj;
    public GameObject glucoseObj;
    public GameObject smallGreen;
    public int big;

    Vector3 lastPostion;
    Vector3 localVelocity;
    private SpBar spBar;
    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp; // 初始化生命值
        target = GameObject.FindGameObjectWithTag("character").GetComponent<Transform>(); // 寻找玩家
        sp = GetComponent<SpriteRenderer>(); // 获取材质
        glucoseObj=GameObject.FindGameObjectWithTag("glucose");
        lastPostion = transform.position;
        spBar=GameObject.FindGameObjectWithTag("spbar").GetComponent<SpBar>();

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
            FullControl.deadGreenBacteria=FullControl.deadGreenBacteria+1;
            if(Random.Range(0,5)==1){
                Instantiate(oxygenObj, transform.position, Quaternion.identity);
            }
            Instantiate(glucoseObj, transform.position+new Vector3(Random.Range(-1f,1f),Random.Range(-1f,1f),transform.position.z), Quaternion.identity);
            if(big==1000){
                Instantiate(smallGreen, 2*transform.position-target.position, Quaternion.identity);
                Instantiate(smallGreen, 2*transform.position-target.position+new Vector3(Random.Range(0f,1f),Random.Range(0f,1f),transform.position.z), Quaternion.identity);
                Instantiate(smallGreen, 2*transform.position-target.position+new Vector3(Random.Range(-1f,0f),Random.Range(-1f,0f),transform.position.z), Quaternion.identity);
            }
            FullControl.sp=FullControl.sp+10;
            spBar.SetSp(FullControl.sp);
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
