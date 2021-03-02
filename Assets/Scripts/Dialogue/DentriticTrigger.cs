using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DentriticTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public Transform dialogueTransform;
    public Transform player;
    public Transform transformCanvas;
    public Request request;
    public List<List<string>> awaitingRequest=new List<List<string>>{
        new List<string>{"Kill 5 green bacteria","In progress","HP +50"},
        new List<string>{"Kill 5 bats","In progress","SP +50"},
        new List<string>{"Complete tutorial","In progress","HP +100"},
        new List<string>{"kill 10 bats","In progress","Oxygen +50"},
        new List<string>{"Kill 10 green bacteria","In progress","Oxygen +100"}};

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
        // Debug.Log(dialogue.sentences);
    	FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
    public void AddRequest(){
        // Random ran=new Random();
        int ranVal=Random.Range(0,awaitingRequest.Count);
        // if(request.tableRequestsHash[ranVal]==1) return;
        // Debug.Log(ranVal);
        request.AddRow(awaitingRequest[ranVal][0],
                       awaitingRequest[ranVal][1],
                       awaitingRequest[ranVal][2],ranVal);
    }
}
