using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testglobal : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
           transform.position=
        transform.position+(Vector3)VJoystick.joystickpos*speed*Time.deltaTime;
    
    }
}
