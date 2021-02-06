using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class tolevel2 : MonoBehaviour
{
    public Animator fade;
    public float transitionTime=1f;
    private Transform target;
    private void Start() {
        target=GameObject.FindGameObjectWithTag("character").GetComponent<Transform>();
    }
    private IEnumerator waitLoad(){
        yield return new WaitForSeconds(transitionTime); 
        Loader.Load(Loader.Scene.Level2);
    }
    private void Update() 
    {
        // Debug.Log(target.position);
        if(target.position.x<=-18.5 && target.position.x>=-20.5 &&
           target.position.y>=-1.5 && target.position.y<=1)
        {
            fade.SetTrigger("out");
            StartCoroutine(waitLoad());
        }
    }
}
