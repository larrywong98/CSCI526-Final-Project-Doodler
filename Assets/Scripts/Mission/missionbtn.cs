using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class missionbtn : MonoBehaviour
{
    public Button m_Btn;
    public Transform missionTransform;
    public Transform canvasTransform;
    void Start(){
        m_Btn.onClick.AddListener(ShowMission);
    }
    public void ShowMission()
    {
        if(FullControl.buttonNum!=0)return ;
        FullControl.buttonNum=3;
        missionTransform.GetChild(1).gameObject.SetActive(true);
        missionTransform.GetChild(2).gameObject.SetActive(true);
        canvasTransform.GetChild(0).gameObject.SetActive(false);
        canvasTransform.GetChild(1).gameObject.SetActive(false);
    }
}

