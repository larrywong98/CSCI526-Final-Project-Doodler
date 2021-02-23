using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toHome : MonoBehaviour
{
    public Button m_Btn;
    void Start(){
        m_Btn.onClick.AddListener(showConfirm);
    }
    public void showConfirm()
    {
        // Debug.Log("to loading");
        Loader.Load(Loader.Scene.MainMenu);
        
        // Loader.Load(Loader.Scene.Level1);
    }
}
