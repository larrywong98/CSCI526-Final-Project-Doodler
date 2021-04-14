using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LoadSaved : MonoBehaviour
{
    [SerializeField] private Animator fade;
    private float transitionTime=1f;
    private Loader.Scene stage;
    public void LoadLastPosition(){
        if(FullControl.savedSpot==1){
            stage=Loader.Scene.Level1Scene1;
        }
        if(FullControl.savedSpot==2){
            stage=Loader.Scene.Level1Scene2;
        }
        if(FullControl.savedSpot==3){
            stage=Loader.Scene.Level1Scene3;
        }
        if(FullControl.savedSpot==4){
            stage=Loader.Scene.Level2;
        }
        if(FullControl.savedSpot==5){
            stage=Loader.Scene.Level3;
        }
        if(FullControl.savedSpot==10){
            stage=Loader.Scene.FinalBossScene;
        }
        fade.SetTrigger("out");
        StartCoroutine(waitLoad());
    }
    private IEnumerator waitLoad(){
        yield return new WaitForSeconds(transitionTime);
        // Loader.Scene stage = (Loader.Scene)Enum.Parse(typeof(Loader.Scene), stageName);
        Loader.Load(stage);
    }
}
