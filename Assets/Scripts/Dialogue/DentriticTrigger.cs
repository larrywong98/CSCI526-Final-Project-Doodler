using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DentriticTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public Transform dialogueTransform;
    public Transform playerTransform;
    public Transform transformCanvas;
    public Request request;
    public GameObject quest;
    // public ShowDialogue showDialogue;
    public int triggeredOnce=0;
    // public static int isTriggered=0;

    void Update(){
        if(VAim.isAttackButtionUp==1)
        Debug.Log("ok");
        if(VAim.isAttackButtionUp==1 && 
           Vector2.Distance(transform.position,playerTransform.position)<1.5f &&
           triggeredOnce==0){
            
            dialogueTransform.GetChild(0).gameObject.SetActive(true);
            transformCanvas.GetChild(0).gameObject.SetActive(false);
            transformCanvas.GetChild(1).gameObject.SetActive(false);
            // dialogueTransform.GetChild(1).gameObject.SetActive(true);
            TriggerDialogue();
        }
        
    }
   
    public void TriggerDialogue ()
    {
        FullControl.isTriggered=1;
        triggeredOnce=1;
    	FindObjectOfType<DialogueManager>().StartDialogue(dialogue,2);
    }
    public void AddRequest(){
        int tmp=Request.table_requests.Count;
        request.AddRow(""+tmp,"Kill 10 green bacteria","10","0");
    }
}
