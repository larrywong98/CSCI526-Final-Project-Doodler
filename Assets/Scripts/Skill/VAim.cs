using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class VAim : MonoBehaviour,IPointerDownHandler,IDragHandler,IPointerUpHandler
{   
    [SerializeField] private float radius;
    // private float drag;
    public static Vector2 joystickpos;
    public static Vector2 attackDirection;
    private Vector2 circlebPos,circlesPos;
    private Vector2 startPos,endPos;

    [SerializeField] private Image imageBig,imageSmall;
    [SerializeField] private float invalidRange;
    private int flag=0;

    // private Vector2 tmp;
    // [SerializeField] private float scaler;
    // private Button btn;
    // child0 joystick
    public void OnDrag(PointerEventData eventData)
    {
        if(flag==1){
            // circlesPos=eventData.position;
            endPos=eventData.position;
            // circlebPos=new Vector2(Camera.main.WorldToScreenPoint(circlebPos).x,Camera.main.WorldToScreenPoint(circlebPos).y);
            // relative coordinate
            // Debug.Log(circlesPos);
            // Debug.Log(Vector2.Distance(circlesPos,circlebPos));
            if(Vector2.Distance(startPos,endPos)<=radius)
            {
                // tmp1=Camera.main.WorldToScreenPoint(circlesPos);
                transform.GetChild(0).GetChild(0).localPosition=endPos-startPos;
                circlesPos=endPos-startPos;
            }
            else
            {
                transform.GetChild(0).GetChild(0).localPosition=
                radius*Vector3.Normalize((Vector3)endPos-(Vector3)startPos);
                circlesPos=transform.GetChild(0).GetChild(0).localPosition;
                // ((Vector3)eventData.position-transform.GetChild(0).position)*radius;
            }
            joystickpos.x=transform.GetChild(0).GetChild(0).localPosition.x;///radius;
            joystickpos.y=transform.GetChild(0).GetChild(0).localPosition.y;///radius;
            if(joystickpos!=Vector2.zero){
                if(Vector2.Distance(circlesPos,circlebPos)<invalidRange){
                    Debug.Log("auto attack");
                    // Debug.Log(Vector2.Distance(circlesPos,circlebPos));
                }else{
                    attackDirection=joystickpos;
                }
            }
            // transform.GetChild(0).position=transform.GetChild(0).position+
            // new Vector3(joystickpos.x,joystickpos.y,transform.GetChild(0).position.z);
            // drag=Vector2.Distance(transform.GetChild(0).GetChild(0).position,
            //                       transform.GetChild(0).position)/radius;
        }
      
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        // transform.GetChild(0).gameObject.SetActive(true);
        // circlebPos =  eventData.position;
        // Debug.Log(eventData.position);
        // Debug.Log( imageBig.color);
        if(eventData.position.x>=892 && eventData.position.x<=1092 && eventData.position.y>=140 && eventData.position.y<=325)
        {
            imageBig.color=new Color(1f,1f,1f,0.93f);
            imageSmall.color=new Color(1f,1f,1f,0.93f);
            startPos=eventData.position;
            flag=1;
        }else{
            flag=0;
        }
        // Vector2 tmp=Camera.main.ScreenToWorldPoint(eventData.position);
        // transform.GetChild(0).position=tmp;
        // Debug.Log(eventData.position);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        // transform.GetChild(0).gameObject.SetActive(false);
        
        imageBig.color=new Color(1f,1f,1f,0.549f);
        imageSmall.color=new Color(1f,1f,1f,0.549f);
        transform.GetChild(0).GetChild(0).localPosition=Vector2.zero;
        joystickpos=Vector2.zero;
        flag=0;
        // drag=0;
    }
}
