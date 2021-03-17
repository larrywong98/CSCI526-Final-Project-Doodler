
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Image hpeffect;
    public float hurtspeed;
    public Animator fade;
    private float transitionTime=1f;
    public void SetMaxHealth(float health){
        slider.maxValue=health;
        slider.value=health;
    }
    public void SetHealth(float health){
        slider.value=health;
    }
    
    void Update(){
        if(hpeffect.fillAmount>slider.value/100f){
            hpeffect.fillAmount=hpeffect.fillAmount-hurtspeed;
        }else{
            hpeffect.fillAmount=slider.value/100f;
        }
        // Debug.Log(hpeffect.fillAmount);
        if(slider.value<=0){
            fade.SetTrigger("out");
            StartCoroutine(waitLoad());
        }
    }
    private IEnumerator waitLoad(){
        yield return new WaitForSeconds(transitionTime);
        Loader.Load(Loader.Scene.MainMenu);
    }
}
