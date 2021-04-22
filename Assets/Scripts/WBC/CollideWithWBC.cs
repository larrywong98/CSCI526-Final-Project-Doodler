using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideWithWBC : MonoBehaviour
{
   public Player player;
   private float hitBackDistance=1f;
   public Transform enemyTransform;
   void Start()
    {
        player=GameObject.FindGameObjectWithTag("character").GetComponent<Player>();
        enemyTransform=GameObject.FindGameObjectWithTag("purplebacteria").GetComponent<Transform>();
    }
   private void OnTriggerEnter2D(Collider2D other){
       if(other.gameObject.tag=="character"){
           player.TakeDamage(10f);
           #region 
            Vector2 difference = other.transform.position-enemyTransform.position ;
            difference.Normalize();
            // difference = (difference / 10.0f) * hitBackDistance;
            difference = difference * hitBackDistance;
            other.transform.position = new Vector2(other.transform.position.x + difference.x,
                                                    other.transform.position.y + difference.y);
            #endregion
       }
   }
}
