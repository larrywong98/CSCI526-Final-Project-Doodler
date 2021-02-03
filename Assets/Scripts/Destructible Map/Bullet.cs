using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float effectArea;
    public LayerMask isDestructible;
    public int damage;
    public GameObject effect;
    // public GameObject arrowPrefab;
    public float speed;
    private Vector2 target;
    public Transform enemyTransform;
    // Start is called before the first frame update
    void Start()
    {
        target=enemyTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=Vector2.MoveTowards(transform.position,target,speed*Time.deltaTime);
        if(Vector2.Distance(transform.position,target)<1.5f){
            GameObject effectTmp=Instantiate(effect,transform.position,Quaternion.identity);
            Destroy(gameObject);
            Destroy(effectTmp,2f);
        }
        // Debug.Log(transform.position);
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("DestructibleWall")){
            Collider2D[] damagedObject=Physics2D.OverlapCircleAll(transform.position,effectArea,isDestructible);
            for(int i=0;i<damagedObject.Length;i++){
                damagedObject[i].GetComponent<Destructible>().health-=damage;
            }
            Debug.Log(damagedObject);
            GameObject effectTmp=Instantiate(effect,transform.position,Quaternion.identity);
            Destroy(gameObject);
            Destroy(effectTmp,2f);
            // i.Getcomponent<Destructible>().health-=damage;
        }
    }
     private void OnDrawGizmosSelected() {
        Gizmos.color=Color.red;
        Gizmos.DrawWireSphere(transform.position,effectArea);    
    }
}
