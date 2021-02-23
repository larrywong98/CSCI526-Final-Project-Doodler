using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Home_Stay : MonoBehaviour
{
    public Button m_Btn;
    public Transform transform;
    void Start(){
        m_Btn.onClick.AddListener(CloseComfirm);
    }
    public void CloseComfirm()
    {
        // Debug.Log("to loading");
       transform.gameObject.SetActive(false);
        
        // Loader.Load(Loader.Scene.Level1);
    }
}
