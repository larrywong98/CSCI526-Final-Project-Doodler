using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpBar : MonoBehaviour
{
    // public Slider slider;
    public Image speffect;
    public Image spapeffect;
    public float consumeSpeed;
    // public Animator fade;
    // private float transitionTime=1f;
    private float maxSp=100f;
    // private void Start() {
    //     spapeffect.fillAmount=FullControl.sp/maxSp;
    // }
    public void SetMaxSp(float sp){
        // slider.maxValue=health;
        // slider.value=health;
        spapeffect.fillAmount=sp/maxSp;
    }
    public void SetSp(float sp){
        // slider.value=health;
        spapeffect.fillAmount=sp/maxSp;
    }
    
    void Update(){
        // if(speffect.fillAmount>slider.value/maxSp){
        if(speffect.fillAmount>spapeffect.fillAmount){
            speffect.fillAmount=speffect.fillAmount-consumeSpeed;
        }else{
            speffect.fillAmount=spapeffect.fillAmount;
        }
        // Debug.Log(speffect.fillAmount);
        // if(spapeffect.fillAmount<=0){
        //     fade.SetTrigger("out");
        //     StartCoroutine(waitLoad());
        // }
    }
    // private IEnumerator waitLoad(){
    //     yield return new WaitForSeconds(transitionTime);
    //     Loader.Load(Loader.Scene.MainMenu);
    // }
}
