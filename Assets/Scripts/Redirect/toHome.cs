using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toHome : MonoBehaviour
{
    public Button m_Btn;
    // public FullControl fc;
    void Start(){
        m_Btn.onClick.AddListener(ToMainMenu);
    }
    public void ToMainMenu()
    {
        // Debug.Log("to loading");
        Loader.Load(Loader.Scene.MainMenu);
        FullControl.buttonNum=0;
        // Loader.Load(Loader.Scene.Level1);
    }
}
