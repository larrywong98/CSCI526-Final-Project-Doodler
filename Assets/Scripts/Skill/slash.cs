using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slash : MonoBehaviour
{
    // public Transform playerTransform;

    private Vector2 difference;
    public Transform spTransform;
    public Button m_Btn;
    // public GameObject target;
    // private PlayerController playerController;
    void Start(){
        m_Btn.onClick.AddListener(slashFunc);
        // playerController=target.GetComponent<PlayerController>();
        // playerTransform=GameObject.FindGameObjectWithTag("character").GetComponent<Transform>().transform;
    }

    void slashFunc()
    {
        difference = VJoystick.lateJoystickPos;
        
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;//Radius -> Degree 弧度转角度
        spTransform.rotation = Quaternion.Euler(0, 0, rotZ);

        spTransform.GetChild(0).gameObject.SetActive(true);
        
    }
}
