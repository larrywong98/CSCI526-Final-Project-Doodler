using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioPriority : MonoBehaviour
{
    private AudioSource audioSource;
    public Slider slider;
    public Slider slider1;
    void Start() {
        audioSource=GameObject.FindGameObjectWithTag("audiomanager").GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        audioSource.volume=slider.value;
        FullControl.soundFx=slider1.value;
    }
}
