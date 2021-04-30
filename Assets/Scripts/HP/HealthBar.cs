using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // public Slider slider;
    public Image hpeffect;
    public Image hpapeffect;
    public float hurtspeed;
    public Animator fade;
    private float transitionTime=1f;
    private float maxlife=100f;
    public void SetMaxHealth(float health){
        // slider.maxValue=health;
        // slider.value=health;
        hpapeffect.fillAmount=health/maxlife;
    }
    public void SetHealth(float health){
        // slider.value=health;
        hpapeffect.fillAmount=health/maxlife;
    }
    
    void Update(){
        // if(hpeffect.fillAmount>slider.value/maxlife){
        if(hpeffect.fillAmount>hpapeffect.fillAmount){
            hpeffect.fillAmount=hpeffect.fillAmount-hurtspeed;
        }else{
            hpeffect.fillAmount=hpapeffect.fillAmount;
        }
        // Debug.Log(hpeffect.fillAmount);
        if(hpapeffect.fillAmount<=0){
            SoundManager.Instance.PlaySound(SoundManager.Instance.DeadClip, volume: 0.05f);
            fade.SetTrigger("out");
            StartCoroutine(waitLoad());
        }
    }
    private IEnumerator waitLoad(){
        yield return new WaitForSeconds(1f);
        yield return new WaitForSeconds(transitionTime);
        Loader.Load(Loader.Scene.MainMenu);
    }
}
