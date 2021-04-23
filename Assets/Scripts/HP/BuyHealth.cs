using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public Image hpBar;
    public Image hpEffectBar;
    public Text glucoseAmount;
    public Text result;
    private Text glucoseText;

    void Start()
    {
        hpBar.fillAmount=0.2f;
        hpEffectBar.fillAmount=hpBar.fillAmount;
        FullControl.hp=20;
        FullControl.glucose=10;
        glucoseText=GameObject.FindGameObjectWithTag("showglucose").GetComponent<Text>();
        glucoseText.text="  "+FullControl.glucose;
    }

    private void AddHealth(float health){
    	FullControl.hp=FullControl.hp+health;
        if(FullControl.hp>100){
            FullControl.hp=100;
        }
    	hpBar.fillAmount=FullControl.hp/100;
        hpEffectBar.fillAmount=FullControl.hp/100;
    }

    public void TakeGlucose(){
    	int amount = int.Parse(glucoseAmount.text);
    	if(FullControl.glucose>=amount){
    		FullControl.glucose=FullControl.glucose-amount;
    		AddHealth(amount*10);
    		glucoseText.text="  "+FullControl.glucose;
    		result.text = "Success!";
    	} else {
    		result.text = "Don't have enough glucose";
    	}
    	
    }
}
