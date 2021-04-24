using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class L1S3Dendritic : MonoBehaviour
{
    public Dialogue dialogue;
    public Transform dialogueTransform;
    public Transform player;
    public Transform transformCanvas;
    public Request request;
    public GameObject quest;
    // public static int isTriggered=0;

    void Update(){
        if(VAim.isAttackButtionUp==1 && 
           Vector2.Distance(transform.position,player.position)<3f){
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
    	FindObjectOfType<DialogueManager>().StartDialogue(dialogue,8);
    }
    public void AddRequest(){
        int tmp=Request.table_requests.Count;
        request.AddRow(""+tmp,"Kill BOSS GOLEM","1","0");
    }
}
