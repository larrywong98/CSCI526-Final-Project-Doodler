using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ToStage : MonoBehaviour
{
    public Animator fade;
    private float transitionTime=1f;
    private int isfirstcollide=0;
    [SerializeField] private string stageName;

    [SerializeField] private DissolveEffect dissolveEffect;
    [ColorUsageAttribute(true, true)]
    [SerializeField] private Color disappearColor;
    // [ColorUsageAttribute(true, true)]
    // [SerializeField] private Color reappearColor;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "character" && isfirstcollide==0)
        { 
            dissolveEffect.Dissolve(1f, disappearColor);
            // Debug.Log("ok");
            fade.SetTrigger("out");
            StartCoroutine(waitLoad());
            isfirstcollide=1;
        }
    }
    
    private IEnumerator waitLoad(){
        yield return new WaitForSeconds(transitionTime);
        Loader.Scene stage = (Loader.Scene)Enum.Parse(typeof(Loader.Scene), stageName);
        Loader.Load(stage);
    }
}
