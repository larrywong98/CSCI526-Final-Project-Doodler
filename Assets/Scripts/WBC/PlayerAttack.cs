// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    void Update()
    {



        // 正式运行时需要被注释的
        // if(Input.GetMouseButtonDown(0)){

        //     Attack();
        // }

        // 判断控制杆被放开，就攻击
        // Debug.Log(VAim.isAttackButtionUp);
        if(VAim.isAttackButtionUp == 1){
            Attack();
            VAim.isAttackButtionUp = 0;
        }


    }

    private void Attack()
    {

        // calculate the angle between mouse click and arrow(to right)
        // Mouse Direction = mouse Pos - current player pos 鼠标位置「目标点位置」-当前位置「人物所在位置」
        Vector2 difference = VAim.attackDirection;
        // Vector2 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;//Radius -> Degree 弧度转角度
        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        transform.GetChild(0).gameObject.SetActive(true);
        transform.parent.GetChild(1).gameObject.SetActive(true); // 手挥舞刀光更新


    }
}
