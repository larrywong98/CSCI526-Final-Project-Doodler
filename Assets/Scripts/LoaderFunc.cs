using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderFunc : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isfirstUpdate=true;
    private void Update(){
        isfirstUpdate=false;
        Loader.LoaderFunc();
    }
}
