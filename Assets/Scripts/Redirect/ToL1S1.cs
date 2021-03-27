using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ToL1S1  : MonoBehaviour
{
    public Button m_Btn;
    [SerializeField]  public Animator fade;
    private float transitionTime=1f;
    void Start(){
        m_Btn.onClick.AddListener(Tol1s1);
    }
    public void Tol1s1()
    {
        // Debug.Log("to loading");
        FullControl.buttonNum=0;
        FullControl.isTriggered=0;
        FullControl.dialogueRBCEnd=0;
        FullControl.id=0;
        FullControl.collectOxygen=0;
        FullControl.deadGreenBacteria=0;
        FullControl.deadboss=0;
        FullControl.glucose=0;
        FullControl.mainCharacterMoveSpeed=10f;
        for( int i=0;i<100;i++){
            FullControl.canOpen[i]=0;
            FullControl.isOpen[i]=0;
            FullControl.enterOnce[i]=0;
        }
        Request.table_requests=new List<List<string>>();
        fade.SetTrigger("out");
        StartCoroutine(waitLoad());

        // Loader.Load(Loader.Scene.Level1);
    }
    private IEnumerator waitLoad(){
        yield return new WaitForSeconds(transitionTime);
        // Loader.Scene stage = (Loader.Scene)Enum.Parse(typeof(Loader.Scene), stageName);
        Loader.Load(Loader.Scene.Level1Scene1);
    }
}