using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stay : MonoBehaviour
{
    public Button m_Btn;
    public Transform transClose;
    // public FullControl fc;
    void Start(){
        m_Btn.onClick.AddListener(CloseComfirm);
    }
    public void CloseComfirm()
    {
        // Debug.Log("to loading");
        transClose.parent.parent.GetChild(2).gameObject.SetActive(true);
        transClose.parent.parent.GetChild(1).gameObject.SetActive(true);
        transClose.GetChild(1).gameObject.SetActive(false);
        transClose.GetChild(2).gameObject.SetActive(false);
        FullControl.buttonNum=0;
        // Loader.Load(Loader.Scene.Level1);
    }
}
