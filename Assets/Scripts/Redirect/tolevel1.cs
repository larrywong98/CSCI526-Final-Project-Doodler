using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class tolevel1 : MonoBehaviour
{
    // Start is called before the first frame update
    // private void Awake() {
    //     transform.Find("btn").GetComponent<Button>().ClickFunc=()=>{
    //         Debug.Log("to loading");
    //         Loader.Load(Loader.Scene.Level1);
    //     };
    // }
    public Button m_Btn;
    void Start(){
        m_Btn.onClick.AddListener(ButtonOnClickEvent);
    }
    public void ButtonOnClickEvent()
    {
        // Debug.Log("to loading");
        Loader.Load(Loader.Scene.Level1);
        
        // Loader.Load(Loader.Scene.Level1);
    }
}
