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
            FullControl.glucose=FullControl.glucose+1;
            glucoseText.text="  "+FullControl.glucose;
            Destroy(gameObject,0f);
            // Debug.Log(FullControl.collectOxygen);
            isfirstcollide=1;
            
        }
    }
}
