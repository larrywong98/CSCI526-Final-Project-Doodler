using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings_Stay : MonoBehaviour
{
    public Button m_Btn;
    [SerializeField] private Transform transform;
    void Start(){
        // transform=GameObject.Find("settings").GetComponent<Panel>().transform;
        m_Btn.onClick.AddListener(CloseComfirm);
    }
    public void CloseComfirm()
    {
        // Debug.Log("to loading");
       transform.GetChild(0).gameObject.SetActive(false);
       transform.GetChild(1).gameObject.SetActive(false);
        
        // Loader.Load(Loader.Scene.Level1);
    }
}
