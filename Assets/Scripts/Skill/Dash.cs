using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [SerializeField] private WbcMovement wbcmovement;
    public void StartDash(){
        wbcmovement.HandleAbility();
        // Debug.Log(Camera.main.ScreenToWorldPoint(transform.localPosition));
    }
    

}
