using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform wbcWaveTransform;
    // public Transform wbcWaveUltimateTransform;
    public Transform slashTransform;
    // public Transform slashUltimateTransform;


    // Update is called once per frame
    void Update()
    {
        
        // 判断控制杆被放开，就攻击
        // Debug.Log(VAim.isAttackButtionUp);
        // Debug.Log(VAim.isAttackButtionUp);
        if(VAim.isAttackButtionUp == 1){
            
            Attack();
            
            
        }
        // if(Input.GetMouseButtonDown(0) && FullControl.isTriggered==0){
        // {
            // VAim.attackDirection=Camera.main.ScreenToWorldPoint(Input.mousePosition)-transform.position;
            // Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            // Attack();
        // }

    }

    private void Attack()
    {

        // calculate the angle between mouse click and arrow(to right)
        // Mouse Direction = mouse Pos - current player pos 鼠标位置「目标点位置」-当前位置「人物所在位置」
        Vector2 difference = VAim.attackDirection;

        // Vector2 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;//Radius -> Degree 弧度转角度
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
        // Debug.Log("ok");

        //普通攻击
        if(FullControl.normalorultimate==0){
            slashTransform.gameObject.SetActive(true);
            if(VAim.attackDirection.x > 0){ //如果朝着反方向挥舞，那么挥刀时人物转向
                wbcWaveTransform.eulerAngles = new Vector3(0, 180, 0);
            }
            wbcWaveTransform.gameObject.SetActive(true); // 手挥舞刀光更新
            VAim.isAttackButtionUp = 0;
            VAim.attackDirection=new Vector2(0f,0f);
        }

        // //大招攻击
        // if(FullControl.normalorultimate==1){
        //     slashUltimateTransform.gameObject.SetActive(true);
        //     if(VAim.attackDirection.x > 0){ //如果朝着反方向挥舞，那么挥刀时转向
        //         wbcWaveUltimateTransform.eulerAngles = new Vector3(0, 180, 0);
        //     }
        //     wbcWaveUltimateTransform.gameObject.SetActive(true); // 手挥舞刀光更新

        // }

    }

}
