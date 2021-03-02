
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Image hpeffect;
    public float hurtspeed=0.001f;
    public void SetMaxHealth(float health){
        slider.maxValue=health;
        slider.value=health;
    }
    public void SetHealth(float health){
        slider.value=health;
    }
    void Update(){
        // if(Input.GetMouseButtonDown(0)){
        //     SetHealth(slider.value-20);
        // }
        if(hpeffect.fillAmount>slider.value/100f){
            hpeffect.fillAmount=hpeffect.fillAmount-hurtspeed;
        }else{
            hpeffect.fillAmount=slider.value/100f;
        }
    }
}
