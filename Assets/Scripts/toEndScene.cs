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
        Debug.Log(target.position);
        if(target.position.x<=-15 && target.position.x>=-20 &&
           target.position.y<=-2 && target.position.y<=0)
        {
            Loader.Load(Loader.Scene.EndScene);
        }
    }
}
