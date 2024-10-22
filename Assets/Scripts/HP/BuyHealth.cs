﻿using System.Collections;
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
    public Text buyText;

    void Start()
    {
        // hpBar.fillAmount=0.2f;
        // hpEffectBar.fillAmount=hpBar.fillAmount;
        // FullControl.hp=20;
        // FullControl.glucose=20;
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

    public IEnumerator colortimer(){
        buyText.color=new Color(0,1,0);
        yield return new WaitForSeconds(0.2f);
        buyText.color=new Color(0,0,0);
    }
    public IEnumerator colortimer1(){
        buyText.color=new Color(1,0,0);
        yield return new WaitForSeconds(0.2f);
        buyText.color=new Color(0,0,0);
    }
    public void TakeGlucose(){
        
    	int amount = int.Parse(glucoseAmount.text);
    	if(FullControl.glucose>=amount*10){
    		FullControl.glucose=FullControl.glucose-amount*10;
            SoundManager.Instance.PlaySound(SoundManager.Instance.AddHealthClip, volume: FullControl.soundFx);

    		AddHealth(amount*50);
    		glucoseText.text="  "+FullControl.glucose;
            StartCoroutine(colortimer());
            if(amount!=0)
    		result.text = "HP restored!";
    	} else {
            StartCoroutine(colortimer1());
    		result.text = "Insufficient glucose";
    	}
    }
}
