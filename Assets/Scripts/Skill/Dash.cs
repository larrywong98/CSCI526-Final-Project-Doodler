using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [SerializeField] private WbcMovement wbcmovement;
    public void StartDash(){
        wbcmovement.HandleAbility();
        SoundManager.Instance.PlaySound(SoundManager.Instance.DashClip, volume: FullControl.soundFx/2f);
        // Debug.Log(Camera.main.ScreenToWorldPoint(transform.localPosition));
    }
    

}
