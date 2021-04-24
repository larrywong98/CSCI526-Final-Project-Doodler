using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickGlucose : MonoBehaviour
{
    private int isfirstcollide=0;
    private Text glucoseText;
    private void Start() {
        glucoseText=GameObject.FindGameObjectWithTag("showglucose").GetComponent<Text>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "character" && isfirstcollide==0)
        {
            SoundManager.Instance.PlaySound(SoundManager.Instance.CoinClip, volume: 0.8f);
            FullControl.glucose=FullControl.glucose+1;
            // Debug.Log(FullControl.glucose);
            glucoseText.text="  "+FullControl.glucose;
            // Debug.Log(glucoseText.text);
            Destroy(gameObject,0f);
            // Debug.Log(FullControl.collectOxygen);
            isfirstcollide=1;
            
        }
    }
}
