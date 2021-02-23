using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenSettings : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Button settings;
    void Start()
    {
        settings.onClick.AddListener(SettingsFunc);
        
    }

    // Update is called once per frame
    void SettingsFunc()
    {
        transform.parent.parent.GetChild(2).gameObject.SetActive(false);
        transform.parent.parent.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(true);
        for(int i=0;i<4;i++){
            transform.GetChild(1).GetChild(i).gameObject.SetActive(true);
        }
    }
    public void OnPointerUp(){
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
    }
}
