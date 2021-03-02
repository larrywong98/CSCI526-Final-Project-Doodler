using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class missionbtn : MonoBehaviour
{
    public Button m_Btn;
    public Transform missionTransform;
    public Transform canvasTransform;
    public GameObject quest;
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
        
        for (int i = 0; i < Request.table_requests.Count; i++)
        // if(Request.table_requests.Count>0)
        {
            GameObject tableRequestObj = GameObject.FindGameObjectWithTag("request");
            GameObject row = GameObject.Instantiate(quest, tableRequestObj.transform.position, Quaternion.identity) as GameObject;
            row.name = "quest" + (i+1);
            row.transform.SetParent(tableRequestObj.transform);
            row.transform.localScale = Vector3.one;
            tableRequestObj.GetComponent<RectTransform>().sizeDelta=
                new Vector2(tableRequestObj.GetComponent<RectTransform>().sizeDelta.x,
                            tableRequestObj.GetComponent<RectTransform>().sizeDelta.y+128);
            row.transform.GetChild(0).GetComponent<Text>().text=Request.table_requests[i][0];
            row.transform.GetChild(1).GetComponent<Text>().text=Request.table_requests[i][1];
            row.transform.GetChild(2).GetComponent<Text>().text=Request.table_requests[i][2];
         }
        // Request.prevCount=Request.table_requests.Count-1;
    }
}

