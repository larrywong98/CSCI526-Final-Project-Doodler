using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class VJoystick : MonoBehaviour,IPointerDownHandler,IDragHandler,IPointerUpHandler
{   
    public float radius;
    public static Vector2 joystickpos;
    public float drag;
    private Vector2 circlebPos;
    private Vector2 circlesPos;
    private Vector2 tmp,tmp1;
    public float scaler;
    // private Button btn;
    // child0 joystick
    public void OnDrag(PointerEventData eventData)
    {
        circlesPos=eventData.position;
        // circlebPos=new Vector2(Camera.main.WorldToScreenPoint(circlebPos).x,Camera.main.WorldToScreenPoint(circlebPos).y);
        // transform.GetChild(0).position=
        //relative coordinate
        // Debug.Log(circlesPos);
        // Debug.Log(Vector2.Distance(circlesPos,circlebPos));
        if(Vector2.Distance(circlesPos,circlebPos)<=radius)
        {
            // tmp1=Camera.main.WorldToScreenPoint(circlesPos);
            transform.GetChild(0).GetChild(0).localPosition=2*(circlesPos-circlebPos);
        }
        else
        {
            transform.GetChild(0).GetChild(0).localPosition=
            scaler*radius*Vector3.Normalize((Vector3)circlesPos-(Vector3)circlebPos);
            // ((Vector3)eventData.position-transform.GetChild(0).position)*radius;
        }
        joystickpos.x=transform.GetChild(0).GetChild(0).localPosition.x/radius;
        joystickpos.y=transform.GetChild(0).GetChild(0).localPosition.y/radius;
        // transform.GetChild(0).position=transform.GetChild(0).position+
        // new Vector3(joystickpos.x,joystickpos.y,transform.GetChild(0).position.z);
        drag=Vector2.Distance(transform.GetChild(0).GetChild(0).position,
                              transform.GetChild(0).position)/radius;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        transform.GetChild(0).gameObject.SetActive(true);
        circlebPos =  eventData.position;
        tmp=Camera.main.ScreenToWorldPoint(eventData.position);
        transform.GetChild(0).position=tmp;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(0).GetChild(0).localPosition=Vector2.zero;
        joystickpos=Vector2.zero;
        drag=0;
    }
}
