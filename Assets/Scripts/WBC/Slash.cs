using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{

    [SerializeField] private float attackDamage; // 武器伤害
    [SerializeField] private float hitBackDistance; // 击退距离
    [SerializeField] private float minDamage, maxDamage, apDamage;
    [SerializeField] private Transform parentTransform;
    public GameObject damageCanvas;
    // public GameObject damagedText;


    public void EndAttack(){
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other){

        if(other.gameObject.tag == "Enemy"){ // we hit enemy

            // Debug.Log("We Hit the enemy !!!!!");

            attackDamage = Random.Range(minDamage, maxDamage);

            // Enemy_Bat enemy = other.gameObject.GetComponent<Enemy_Bat>(); //获取敌人
            Enemy_GreenBacteria enemy = other.gameObject.GetComponent<Enemy_GreenBacteria>(); 

            if(!enemy.isAttacked){ // 只有当敌人isAttacked为false时才能造成伤害
                enemy.TakenDamage(attackDamage); //  给敌人造成伤害
                // Vector2 showposition=Camera.main.WorldToScreenPoint(other.transform.position);
                // Vector3 showposition=new Vector3(Camera.main.WorldToScreenPoint(other.transform.position).x,
                //                         Camera.main.WorldToScreenPoint(other.transform.position).y,0);
                // Debug.Log(other.transform.position);
                // Debug.Log(showposition);
                DamageNum damagable = Instantiate(damageCanvas, other.transform.position, Quaternion.identity).GetComponent<DamageNum>(); //如果需要旋转的话就是quaternion.rotation 
                damagable.ShowUIDamage(Mathf.RoundToInt(attackDamage)); // show damage
                // damagedText
                // DamageNum damagable = Instantiate(damagedText, other.transform.position, Quaternion.identity).GetComponent<DamageNum>(); //如果需要旋转的话就是quaternion.rotation 
                // damagable.transform.parent=parentTransform.transform;
                // damagable.ShowUIDamage(Mathf.RoundToInt(attackDamage)); // show damage
                
                StartCoroutine(FindObjectOfType<camcontroller>().CameraShakeCo(0.1f, 0.4f)); // camera shake

                // 击退效果
                #region 
                Vector2 difference = other.transform.position - transform.position;
                difference.Normalize();
                // difference = (difference / 10.0f) * hitBackDistance;
                difference = difference * hitBackDistance;
                other.transform.position = new Vector2(other.transform.position.x + difference.x,
                                                        other.transform.position.y + difference.y);
                #endregion

            }
            
        }
    }
}
