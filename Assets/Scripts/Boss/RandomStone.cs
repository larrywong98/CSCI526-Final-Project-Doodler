using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStone : MonoBehaviour
{
    public GameObject stone;
    public Transform playerTransform;
    public float waitTime=10f;
    private int count=0;
    private GameObject tmp;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    private float stoneRange=5f;
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 movement=(Vector3)playerTransform.position-transform.position;
        rb.velocity=new Vector2(movement.normalized.x,movement.normalized.y)*speed;
   
        // Debug.Log(playerTransform.position);
        // if(count>0)return ;
        
        
        // StartCoroutine(waitStone());
        if(count%50==0){
            Vector2 createPos=new Vector2(playerTransform.position.x-35.78f+UnityEngine.Random.Range(-stoneRange,stoneRange),playerTransform.position.y+33f+UnityEngine.Random.Range(-stoneRange,stoneRange));
            tmp=Instantiate(stone, createPos, Quaternion.identity);
        }
        count=count+1;
        

    }
    private IEnumerator waitStone(){
        yield return new WaitForSeconds(waitTime);
       
        // Destroy(tmp);
    }
}
