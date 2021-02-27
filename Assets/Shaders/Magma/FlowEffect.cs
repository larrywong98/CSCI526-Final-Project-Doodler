using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowEffect : MonoBehaviour
{
    private float flowSpeed;
    [SerializeField] private Material material;
    [SerializeField] private int flag=1;
    private float targetSpeed;
    // Start is called before the first frame update
    void Start()
    {
        flowSpeed=Random.Range(0f, 8f)*0.02f;
        material.SetFloat("_Speed", flowSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(flowSpeed);
        if(flag%100==0){
            targetSpeed=Random.Range(0f, 8f)*0.02f;
            Debug.Log(targetSpeed);
            Debug.Log(flowSpeed);
            if(targetSpeed<flowSpeed){
                for(;flowSpeed<targetSpeed;){
                    material.SetFloat("_Speed", flowSpeed);
                    flowSpeed=flowSpeed-0.002f;
                }
            }else{
                for(;flowSpeed>targetSpeed;){
                    material.SetFloat("_Speed", flowSpeed);
                    flowSpeed=flowSpeed+0.002f;
                }
            }
            flag=0;
        }
        flag=flag+1;
    }
}
