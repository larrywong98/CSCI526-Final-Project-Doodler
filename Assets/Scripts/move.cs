using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float speed;
    // private Rigidbody rgd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // rgd.AddForce((Vector3)VJoystick.joystickpos*speed);
        transform.position=transform.position+(Vector3)VJoystick.joystickpos*speed*Time.deltaTime;
    
    }
}
