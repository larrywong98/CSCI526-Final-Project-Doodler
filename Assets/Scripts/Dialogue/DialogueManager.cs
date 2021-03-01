using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
	public Text nameText;
	public Text dialogueText;

	public Animator animator;
	public Transform dialogueTransform;

	public Queue<string> sentences;
	public Transform transformCanvas;
	public DentriticTrigger dentriticTrigger;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue)
    {
    	// animator.SetBool("IsOpen", true);

    	// Debug.Log("Start dialogue with " + dialogue.name);
    	nameText.text = dialogue.name;

    	sentences.Clear();

    	foreach (string sentence in dialogue.sentences)
    	{
    		sentences.Enqueue(sentence);
    	}

    	DisplayNextSentence();
    }

    public void DisplayNextSentence ()
    {
    	if (sentences.Count == 0)
    	{
    		EndDialogue();
    		return;
    	}

    	string sentence = sentences.Dequeue();

    	dialogueText.text = sentence;

        // Debug.Log(sentence);
    }

    void EndDialogue()
    {
    	// Debug.Log("End");
		dialogueTransform.GetChild(0).gameObject.SetActive(false);
		transformCanvas.GetChild(0).gameObject.SetActive(true);
		transformCanvas.GetChild(1).gameObject.SetActive(true);
		// dialogueTransform.GetChild(1).gameObject.SetActive(false);
    	// animator.SetBool("IsOpen", false);
		dentriticTrigger.AddRequest();
    }
}
