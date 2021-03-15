using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{

    // public Animator animator;
    
    // public GameObject arrowPrefab;

    public float speed;
    public float stoppingDistance;

    public Rigidbody2D rb;

    private Transform target;



    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("character").GetComponent<Transform>();

        // Debug.Log(target);

    }

    // Update is called once per frame
    void Update()
    {

        Follow();


    }


    // private void SetAnimationAttr(Vector3 movement){ // 单独进行动画参数设置
    //     // rgd = GetComponent<Rigidbody>();

    //     animator.SetFloat("Horizontal", movement.x);
    //     animator.SetFloat("Vertical", movement.y);

    //     if(movement.magnitude > 0.2){
    //         animator.SetFloat("Magnitude", movement.magnitude);
    //     }else{
    //         animator.SetFloat("Magnitude", 0.0f);
    //     }
        
        
    //     // transform.position = transform.position + movement* speed * Time.deltaTime;
    //     // rb.velocity=new Vector2(movement.x,movement.y)*speed;
    // }

    private void Follow(){ //跟随功能


       if(Vector2.Distance(transform.position, target.position) > stoppingDistance){

           
            // Debug.Log("Follow function runs");
           
            Vector3 movement = Vector3.MoveTowards(transform.position, target.position, Vector2.Distance(transform.position, target.position) - stoppingDistance) 
                                - transform.position;

            // SetAnimationAttr(movement);

            
            // transform.position = transform.position + movement* speed * Time.deltaTime;


           transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);  // 单独进行移动         


       }
       
        // Vector3 movement = Vector2.MoveTowards(transform.position, target.position, 1.0f);


        // Vector2 rotation = new Vector2 (transform.rotation.x, transform.rotation.y);

        // rotation.Normalize();

        // Debug.Log(rotation.x);

    }




}
