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
    public static int isAttackButtionUp = 0; // 为1则进行攻击，为0则表示不攻击
    public static int isChoosingButtonUp=0;
    private Vector2 circlebPos,circlesPos;
    private Vector2 startPos,endPos;

    [SerializeField] private Image imageBig,imageSmall;
    [SerializeField] private float invalidRange;
    private int flag=0; // 
    // [SerializeField] private Collider2D col;
    // public GameObject slashObject;
    [SerializeField] private Transform transformBig;
    private float margin=1f;
    private Vector3 eventPos;

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
            if(Vector2.Distance(startPos,endPos)<=radius) // 如果攻击拖动小于瞄准框，那么
            {
                // tmp1=Camera.main.WorldToScreenPoint(circlesPos);
                transformBig.GetChild(0).localPosition=endPos-startPos; // 取瞄准框内测的小圆，拉倒哪里就是哪里
                circlesPos=endPos-startPos;
            }
            else
            { // 否则（选的范围超出大圆圈），贴着边
                transformBig.GetChild(0).localPosition=
                radius*Vector3.Normalize((Vector3)endPos-(Vector3)startPos);
                circlesPos=transformBig.GetChild(0).localPosition;
                // ((Vector3)eventData.position-transformBig.position)*radius;
            }
            joystickpos.x=transformBig.GetChild(0).localPosition.x;///radius;  //给当前joystick的方向赋值
            joystickpos.y=transformBig.GetChild(0).localPosition.y;///radius;
            if(joystickpos!=Vector2.zero){
                if(Vector2.Distance(circlesPos,circlebPos)<invalidRange){ // 如果小于dead阈值，就自动攻击
                    Debug.Log("auto attack");
                    // Debug.Log(Vector2.Distance(circlesPos,circlebPos));
                }else{
                    attackDirection=joystickpos; // 否则攻击方向就是joystickpos
                    // Debug.Log(attackDirection);
                    
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
        // Debug.Log(Camera.main.ScreenToWorldPoint(transform.position));
        // Debug.Log(transformBig.position);
        eventPos=Camera.main.ScreenToWorldPoint(eventData.position);
        // Debug.Log(eventData.position);

        // Bounds bound=col.bounds;
        // Debug.Log(bound);
        // Debug.Log(bound.Contains(eventData.position));
        // Debug.Log(onscreen);
        // Debug.Log(eventPos);
        // Debug.Log(transformBig.position);
        
        if(eventPos.x>=transformBig.position.x-margin && eventPos.x<=transformBig.position.x+margin && 
            eventPos.y>=transformBig.position.y-margin && eventPos.y<=transformBig.position.y+margin)
        {

            imageBig.color=new Color(1f,1f,1f,0.93f);
            imageSmall.color=new Color(1f,1f,1f,0.93f);
            startPos=eventData.position;
            flag=1;
            // Debug.Log("okkkkkkk");
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
        // slashObject.slashFunc();
        // Vector3 eventPos=Camera.main.ScreenToWorldPoint(eventData.position);
        if(eventPos.x>=transformBig.position.x-margin && eventPos.x<=transformBig.position.x+margin && 
            eventPos.y>=transformBig.position.y-margin && eventPos.y<=transformBig.position.y+margin)
        {
            imageBig.color=new Color(1f,1f,1f,0.549f);
            imageSmall.color=new Color(1f,1f,1f,0.549f);
            transformBig.GetChild(0).localPosition=Vector2.zero;
            joystickpos=Vector2.zero;
            flag=0;
            // drag=0;
            isAttackButtionUp = 1;
            StartCoroutine(choose());
            
        }
    }
    public IEnumerator choose(){
        isChoosingButtonUp=1;
        yield return new WaitForSeconds(0.2f);
        isChoosingButtonUp=0;
    }

}
