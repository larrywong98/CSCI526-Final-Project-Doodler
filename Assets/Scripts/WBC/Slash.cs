using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{

    [SerializeField] private float attackDamage; // 武器伤害
    [SerializeField] private float hitBackDistance; // 击退距离
    [SerializeField] private float minDamage, maxDamage, apDamage;
    // [SerializeField] private Transform parentTransform;
    public GameObject damageCanvas;
    // public Enemy_Boss enemy;
    public GameObject thrust2;
    public GameObject thrust3;



    public void EndAttack(){
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other){
    // private void OnCollisionEnter2D(Collision collision){
        if(other.gameObject.tag == "Enemy"){ // we hit enemy
            attackDamage = Random.Range(minDamage, maxDamage);
            // Enemy_Bat enemy = other.gameObject.GetComponent<Enemy_Bat>(); //获取敌人
            Enemy_GreenBacteria enemy = other.gameObject.GetComponent<Enemy_GreenBacteria>();
            if(!enemy.isAttacked){ // 只有当敌人isAttacked为false时才能造成伤害
                enemy.TakenDamage(attackDamage); //  给敌人造成伤害
                DamageNum damagable = Instantiate(damageCanvas, other.transform.position, Quaternion.identity).GetComponent<DamageNum>(); //如果需要旋转的话就是quaternion.rotation 
                damagable.ShowUIDamage(Mathf.RoundToInt(attackDamage)); // show damage
                // displayEnemyHittedEffect(enemy.GetComponent<Transform>().position); // 显示敌人被击中时的刀光特效
                if(FullControl.normalorultimate==0)
                {
                    Instantiate(thrust2,other.transform.position,Quaternion.identity);
                }
                else
                {
                    Instantiate(thrust3,other.transform.position+new Vector3(2.5f,0f,other.transform.position.z),Quaternion.identity);
                }
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
    
        if(other.gameObject.tag == "boss"){ // we hit enemy
            attackDamage = Random.Range(minDamage, maxDamage);
            Enemy_Boss enemy=other.gameObject.GetComponent<Enemy_Boss>();
            if(!enemy.isAttacked){ // 只有当敌人isAttacked为false时才能造成伤害
                enemy.TakenDamage(attackDamage); //  给敌人造成伤害
                DamageNum damagable = Instantiate(damageCanvas, other.transform.position, Quaternion.identity).GetComponent<DamageNum>(); //如果需要旋转的话就是quaternion.rotation 
                damagable.ShowUIDamage(Mathf.RoundToInt(attackDamage)); // show damage
                if(FullControl.normalorultimate==0)
                {
                    Instantiate(thrust2,other.transform.position,Quaternion.identity);
                }
                else
                {
                    Instantiate(thrust3,other.transform.position+new Vector3(2.5f,0f,other.transform.position.z),Quaternion.identity);
                }
                StartCoroutine(FindObjectOfType<camcontroller>().CameraShakeCo(0.1f, 0.4f)); // camera shake
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

        if(other.gameObject.tag == "meatshield"){ // we hit enemy
            attackDamage = Random.Range(minDamage, maxDamage);
            MeatShield enemy=other.gameObject.GetComponent<MeatShield>();
            if(!enemy.isAttacked){ // 只有当敌人isAttacked为false时才能造成伤害
                enemy.TakenDamage(attackDamage); //  给敌人造成伤害
                DamageNum damagable = Instantiate(damageCanvas, other.transform.position, Quaternion.identity).GetComponent<DamageNum>(); //如果需要旋转的话就是quaternion.rotation 
                damagable.ShowUIDamage(Mathf.RoundToInt(attackDamage)); // show damage  
                if(FullControl.normalorultimate==0)
                {
                    Instantiate(thrust2,other.transform.position,Quaternion.identity);
                }
                else
                {
                    Instantiate(thrust3,other.transform.position+new Vector3(2.5f,0f,other.transform.position.z),Quaternion.identity);
                }
                StartCoroutine(FindObjectOfType<camcontroller>().CameraShakeCo(0.1f, 0.4f)); // camera shake
                
                // #region 
                // Vector2 difference = other.transform.position - transform.position;
                // difference.Normalize();
                // // difference = (difference / 10.0f) * hitBackDistance;
                // difference = difference * hitBackDistance;
                // other.transform.position = new Vector2(other.transform.position.x + difference.x,
                //                                         other.transform.position.y + difference.y);
                // #endregion
            }
        }
    }

    // private void displayEnemyHittedEffect(Vector3 target){ // 在怪物被击中时，在怪物的位置生成刀光爆炸特效

    //     Transform par = gameObject.transform.parent;

    //     GameObject enemyHittedEffect = par.gameObject.transform.GetChild(1).gameObject;

    //     enemyHittedEffect.GetComponent<Transform>().position = target;
        
    //     enemyHittedEffect.SetActive(true);

    // }
}
