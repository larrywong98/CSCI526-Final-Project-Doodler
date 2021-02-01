using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class toEndScene : MonoBehaviour
{
    private Transform target;
    private void Start() {
        target=GameObject.FindGameObjectWithTag("character").GetComponent<Transform>();
    }
    private void Update() 
    {
        // Debug.Log(target.position);
        if(target.position.x<=-16.5 && target.position.x>=-18.5 &&
           target.position.y>=-4 && target.position.y<=-1.5)
        {
            Loader.Load(Loader.Scene.EndScene);
        }
    }
}
