using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class glucoseinit : MonoBehaviour
{
    void Start()
    {
        transform.GetComponent<Text>().text="  "+FullControl.glucose;
    }
}
