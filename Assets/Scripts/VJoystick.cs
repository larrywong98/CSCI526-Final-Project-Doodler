using UnityEngine;
using UnityEngine.EventSystems;
public class VJoystick : MonoBehaviour,IPointerDownHandler,IDragHandler,IPointerUpHandler
{   
    public float radius;
    public static Vector2 pos;
    public float drag;
    // child0 joystick
    public void OnDrag(PointerEventData eventData)
    {
        if(Vector2.Distance(eventData.position,transform.GetChild(0).position)<=radius)
        {
            transform.GetChild(0).GetChild(0).position=eventData.position;
        }
        else
        {
            transform.GetChild(0).GetChild(0).position=
            transform.GetChild(0).position+
            Vector3.Normalize((Vector3)eventData.position-transform.GetChild(0).position)*radius;
            // ((Vector3)eventData.position-transform.GetChild(0).position)*radius;
        }
        pos.x=transform.GetChild(0).GetChild(0).localPosition.x/radius;
        pos.y=transform.GetChild(0).GetChild(0).localPosition.y/radius;
        drag=Vector2.Distance(transform.GetChild(0).GetChild(0).position,
                              transform.GetChild(0).position)/radius;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(0).position=eventData.position;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(0).GetChild(0).localPosition=Vector2.zero;
        pos=Vector2.zero;
        drag=0;
    }
}
