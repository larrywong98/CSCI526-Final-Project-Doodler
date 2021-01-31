using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderFunc : MonoBehaviour
{
    private bool isFirst=true;
    private void Update(){
        if(isFirst==true){
            isFirst=false;
            Loader.onLoaderFunc();
        }
    }
}
