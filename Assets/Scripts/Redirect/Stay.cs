using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stay : MonoBehaviour
{
    public Button m_Btn;
    public Transform transClose;
    public Transform canvasTransform;
    // public FullControl fc;
    void Start(){
        m_Btn.onClick.AddListener(Close);
    }
    public void Close()
    {
        //清除任务
        GameObject tableRequestObj = GameObject.FindGameObjectWithTag("request");
        // Debug.Log(Request.table_requests.Count);
        if(Request.table_requests.Count>0){
            GameObject[] findTableRequest=GameObject.FindGameObjectsWithTag("requestItem");
            // Debug.Log(findTableRequest.Length);
            for (int i = 0; i < Request.table_requests.Count; i++)
            {
                tableRequestObj.GetComponent<RectTransform>().sizeDelta=
                new Vector2(tableRequestObj.GetComponent<RectTransform>().sizeDelta.x,
                            tableRequestObj.GetComponent<RectTransform>().sizeDelta.y-128);
                Destroy(findTableRequest[i]);
            }
           
        }
        // TreasureChest.enterOnce=0;
       
        // Debug.Log("to loading");
        // canvasTransform.GetChild(0).gameObject.SetActive(true);
        // canvasTransform.GetChild(1).gameObject.SetActive(true);
        transClose.GetChild(1).gameObject.SetActive(false);
        transClose.GetChild(2).gameObject.SetActive(false);
        FullControl.buttonNum=0;
        FullControl.isTriggered=0;
        
        // Loader.Load(Loader.Scene.Level1);
    }
}
