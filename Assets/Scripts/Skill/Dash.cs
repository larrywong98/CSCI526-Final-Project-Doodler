using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    private int flag;
    // private void Update() {
    //     StartCoroutine(waitForSeconds());
    // }
    public void dash()
    {
        Debug.Log(flag);
        flag=0;
    }
    // public IEnumerator waitForSeconds()
    // {
    //     yield return new WaitForSeconds(500f);
    // }

}
