using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public static class Loader 
{
    //
    private class LoadingBehav: MonoBehaviour {}
    //private Action need public function
    public static Action onLoaderFunc;
    private static AsyncOperation asyncOp;
    public enum Scene{
        MainMenu,
        Level1,
        Level2,
        EndScene,
        Loading
    }
    // public static void LoaderFunc(){
    //     if(onLoaderFunc!=null){
    //         onLoaderFunc();
    //         onLoaderFunc=null;
    //     }
    // }
    // Async loading required 
    private static IEnumerator LoadSceneAsync(Scene scene){
        // yield return null;
        asyncOp=SceneManager.LoadSceneAsync(scene.ToString());
        asyncOp.allowSceneActivation = false;
        while(!asyncOp.isDone){
            yield return null;
            if (Input.anyKeyDown) {
                asyncOp.allowSceneActivation = true;
            }
        }
    }
    public static float LoadingProgress(){
        if(asyncOp!=null){
            return asyncOp.progress;
        }else{
            return 0.1f;
        }
    }
    public static void Load(Scene scene){
        VJoystick.joystickpos=Vector2.zero;
        onLoaderFunc=()=>{
            GameObject loadingGo=new GameObject("Loading");
            loadingGo.AddComponent<LoadingBehav>().StartCoroutine(LoadSceneAsync(scene));
            // LoadSceneAsync(scene);
        };
        SceneManager.LoadScene(Scene.Loading.ToString());
    }
    
}
