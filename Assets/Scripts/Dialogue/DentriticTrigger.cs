using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DentriticTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public Transform dialogueTransform;
    public Transform player;
    public Transform transformCanvas;
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
}
