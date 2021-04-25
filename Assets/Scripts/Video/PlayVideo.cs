using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class PlayVideo : MonoBehaviour {

    //定义参数获取VideoPlayer组件和RawImage组件

    private VideoPlayer videoPlayer;
    public Animator fade;
    private RawImage rawImage;

    // Use this for initialization

    void Start () {

        //获取场景中对应的组件

        videoPlayer = this.GetComponent <VideoPlayer> ();

        rawImage = this.GetComponent <RawImage> ();

    }

    

    private IEnumerator wait(){
        yield return new WaitForSeconds(13f);
        fade.SetTrigger("out");
        yield return new WaitForSeconds(0.5f);
        Loader.Load(Loader.Scene.MainMenu);
    }

    void Update () {

        //如果videoPlayer没有对应的视频texture，则返回

        if(videoPlayer.texture == null){
            StartCoroutine(wait());
            return;

        }

        //把VideoPlayerd的视频渲染到UGUI的RawImage

        rawImage.texture = videoPlayer.texture;

    }

}