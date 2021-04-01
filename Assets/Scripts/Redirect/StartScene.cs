using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour
{
    public int spot;
    // Start is called before the first frame update
    void Start()
    {
        FullControl.savedSpot=spot;
    }
}
