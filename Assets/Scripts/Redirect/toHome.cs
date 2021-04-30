using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toHome : MonoBehaviour
{
    public Button m_Btn;
    // [SerializeField] private Animator fade;
    // private float transitionTime=1f;
    // public FullControl fc;
    void Start(){
        m_Btn.onClick.AddListener(ToMainMenu);
    }
    public void ToMainMenu()
    {
        // Debug.Log("to loading");
        Loader.Load(Loader.Scene.MainMenu);
        // StartCoroutine(waitLoad());
        FullControl.buttonNum=0;
        // Loader.Load(Loader.Scene.Level1);
    }
    // private IEnumerator waitLoad(){
    //     yield return new WaitForSeconds(transitionTime);
    //     // Loader.Scene stage = (Loader.Scene)Enum.Parse(typeof(Loader.Scene), stageName);
    //     Loader.Load(Loader.Scene.MainMenu);
    // }
}
