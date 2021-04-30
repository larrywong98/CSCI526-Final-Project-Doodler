using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatItem : MonoBehaviour
{
    private float smoothspeed;
    private Vector3 startPos;
    private int upordown=0;
    private float thresholdY=0.1f;
    private float thresholdX;


    private void Start(){
        startPos = transform.position;
        smoothspeed=Random.Range(0.4f,0.6f);
        thresholdX=Random.Range(-0.05f,0.05f);
    }
    private void LateUpdate() {
        if(transform.position.y<startPos.y-thresholdY){
            thresholdX=Random.Range(-0.05f,0.05f);
            upordown=0;
        }
        if(transform.position.y>startPos.y+thresholdY){
            thresholdX=Random.Range(-0.05f,0.05f);
            upordown=1;
        }
        if(upordown==0){
            if(transform.position.y<startPos.y+thresholdY){
                transform.position=Vector3.Lerp(
                    transform.position,new Vector3(transform.position.x+thresholdX,startPos.y+(thresholdY+0.1f),transform.position.z),
                    smoothspeed * Time.deltaTime);
                transform.position=new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }
        }
        if(upordown==1){
            if(transform.position.y>startPos.y-thresholdY){
                transform.position=Vector3.Lerp(
                    transform.position,new Vector3(transform.position.x+thresholdX,startPos.y-(thresholdY+0.1f),transform.position.z),
                    smoothspeed * Time.deltaTime);
                transform.position=new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }
        }
    }
}
