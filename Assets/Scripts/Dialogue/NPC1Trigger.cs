﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC1Trigger : MonoBehaviour
{
    public Dialogue dialogue;
    public Transform dialogueTransform;
    public Transform playerTransform;
    public Transform transformCanvas;
    public Request request;
    public GameObject quest;
    public int triggeredOnce=0;

    void Update(){
        if(Input.GetKeyDown(KeyCode.Space) && 
           Vector2.Distance(transform.position,playerTransform.position)<1.5f && 
           triggeredOnce==0)
        {
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
    	FindObjectOfType<DialogueManager>().StartDialogue(dialogue,1);
    }
    public void AddRequest(){
        int tmp=Request.table_requests.Count;
        request.AddRow(""+tmp,"Deliver Oxygen","5","0");
    }
}