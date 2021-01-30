using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public static class Loader 
{
    private static Action onLoaderFunc;
    public enum Scene{
        MainMenu,
        Level1,
        Level2,
        EndScene,
        Loading
    }
    public static void LoaderFunc(){
        if(onLoaderFunc!=null){
            onLoaderFunc();
            onLoaderFunc=null;
        }
    }
    public static void Load(Scene scene){
        // SceneManager.LoadScene(Scene.Loading.ToString());
        VJoystick.joystickpos=Vector2.zero;
        onLoaderFunc=()=>{
            SceneManager.LoadScene(scene.ToString());
        };
        SceneManager.LoadScene(Scene.Loading.ToString());

        // SceneManager.LoadScene(scene.ToString());
    }
}
