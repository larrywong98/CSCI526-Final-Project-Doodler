using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingProgress : MonoBehaviour
{
    private Image bar;
    void Start()
    {
        
    }
    private void Awake()
    {
        bar=transform.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        bar.fillAmount=Loader.LoadingProgress();
    }
}
