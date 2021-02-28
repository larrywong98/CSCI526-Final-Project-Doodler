using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenSettings : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Button settings;
    public Transform transClose;
    void Start()
    {
        settings.onClick.AddListener(SettingsFunc);
        
    }

    void SettingsFunc()
    {
        if(FullControl.buttonNum!=0)return ;
        FullControl.buttonNum=1;
        transClose.parent.parent.GetChild(2).gameObject.SetActive(false);
        transClose.parent.parent.GetChild(1).gameObject.SetActive(false);
        transClose.GetChild(1).gameObject.SetActive(true);
        transClose.GetChild(2).gameObject.SetActive(true);
        // for(int i=0;i<4;i++){
        //     transClose.GetChild(2).GetChild(i).gameObject.SetActive(true);
        // }
    }
    // public void OnPointerUp(){
    //     transClose.GetChild(0).gameObject.SetActive(false);
    //     transClose.GetChild(1).gameObject.SetActive(false);
    // }
}
