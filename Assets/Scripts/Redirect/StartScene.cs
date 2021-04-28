using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour
{
    public int spot;
    public Request request;
    // Start is called before the first frame update
    void Start()
    {
        FullControl.savedSpot=spot;
        // SoundManager.Instance.PlaySound(SoundManager.Instance.MusicClip, volume: 0.8f);
        // if(spot==2){
        //     int tmp=Request.table_requests.Count;
        //     request.AddRow(""+tmp,"Deliver Oxygen","5","0");
            // tmp=Request.table_requests.Count;
            // request.AddRow(""+tmp,"Kill 10 green bacteria","10","0");
            // tmp=Request.table_requests.Count;
            // request.AddRow(""+tmp,"Kill BOSS GOLEM","1","0");
        // }
    }
}
