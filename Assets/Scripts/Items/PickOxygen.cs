using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickOxygen : MonoBehaviour
{
    // [SerializeField]private Transform playerTransform;
    // [SerializeField] private Collider2D selfcollider;
    
    private int isfirstcollide=0;

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "character" && isfirstcollide==0)
        { 
            SoundManager.Instance.PlaySound(SoundManager.Instance.ItemClip, volume: FullControl.soundFx);
            FullControl.collectOxygen=FullControl.collectOxygen+1;
            Destroy(gameObject,0f);
            // Debug.Log(FullControl.collectOxygen);
            isfirstcollide=1;
            
        }
    }
}
