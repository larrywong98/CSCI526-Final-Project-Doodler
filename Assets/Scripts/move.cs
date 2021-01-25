using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class move : MonoBehaviour {
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log( VJoystick.pos);
        transform.position=
        transform.position+(Vector3)VJoystick.pos*speed*Time.deltaTime;
    }
}
