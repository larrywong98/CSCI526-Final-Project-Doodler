using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitWBC : MonoBehaviour
{ 
    private float hitBackDistance=1.5f;
    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Enemy"){ // we hit enemy
            // 击退效果
            // Debug.Log( other.transform.position - transform.position);
            // #region 
            Vector2 difference =transform.parent.position-other.transform.position;
            difference.Normalize();
            difference = difference * hitBackDistance;
            transform.parent.position = new Vector2(transform.parent.position.x + difference.x,
                                             transform.parent.position.y + difference.y);
            // #endregion
            
        }
    }
    
}
