using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DentriticTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public Transform dialogueTransform;
    public Transform player;
    public Transform transformCanvas;
    public Request request;
    public GameObject quest;

    void Update(){
        if(Input.GetKeyDown(KeyCode.Space) && Vector2.Distance(transform.position,player.position)<1.5f){
            dialogueTransform.GetChild(0).gameObject.SetActive(true);
            transformCanvas.GetChild(0).gameObject.SetActive(false);
            transformCanvas.GetChild(1).gameObject.SetActive(false);
            // dialogueTransform.GetChild(1).gameObject.SetActive(true);
            TriggerDialogue();
        }
    }
   
    public void TriggerDialogue ()
    {
    	FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
    public void AddRequest(){
        if(Request.awaitingRequest.Count==0){
            Debug.Log("print no more requests");
            return ;
        }
        int ranVal=Random.Range(0,Request.awaitingRequest.Count);
        // countNumRequests=countNumRequests+1;
        // if(request.tableRequestsHash[ranVal]==1) return;
        // Debug.Log(ranVal);
        // while(countNumRequests<=Request.awaitingRequest.Count && Request.tableRequestsHash[ranVal]==1){
        //     ranVal=Random.Range(0,Request.awaitingRequest.Count);
        // }
        request.AddRow(Request.awaitingRequest[ranVal][1],
                       Request.awaitingRequest[ranVal][2],
                       Request.awaitingRequest[ranVal][3],ranVal);
        Request.awaitingRequest.Remove(Request.awaitingRequest[ranVal]);
    }
}
