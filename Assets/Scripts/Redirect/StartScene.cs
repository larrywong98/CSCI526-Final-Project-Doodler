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
        // SoundManager.Instance.PlaySound(SoundManager.Instance.MusicClip, volume: 0.8f);
    }
}
