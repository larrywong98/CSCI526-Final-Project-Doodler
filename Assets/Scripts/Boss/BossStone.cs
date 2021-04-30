using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStone : MonoBehaviour
{
    // [SerializeField]private Transform playerTransform;
    // [SerializeField] private Collider2D selfcollider;
    private int isfirstcollide=0;
    private Player player;
    
    private void Start() {
        player=GameObject.FindGameObjectWithTag("character").GetComponent<Player>();
        
    }
    public IEnumerator explode(){
        yield return null;
        SoundManager.Instance.PlaySound(SoundManager.Instance.ExplodeClip, volume: FullControl.soundFx);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(explode());
        if(other.gameObject.tag == "character" && isfirstcollide==0)
        {
            player.TakeDamage(37f);
        }
        StartCoroutine(FindObjectOfType<camcontroller>().CameraShakeCo(0.05f, 1.3f));
    }
}
