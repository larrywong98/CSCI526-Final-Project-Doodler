using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDialogue : MonoBehaviour
{
    public float Duration = 0.4f;
    public CanvasGroup canvGroup;
    public GameObject panel;
    public Transform npcTransform;


    public void showD()
    {
        // panel.transform=npcTransform;
        panel.SetActive(true);
        StartCoroutine(DoFade(canvGroup, canvGroup.alpha, 0));
    }

    public IEnumerator DoFade(CanvasGroup canvGroup, float start, float end)
    {
    	yield return new WaitForSeconds(2);
    	float counter = 0f;
    	while(counter < Duration)
    	{
    		counter += Time.deltaTime;
    		canvGroup.alpha = Mathf.Lerp(start, end, counter/Duration);
    		yield return null;
    	}
        canvGroup.alpha=start;
        panel.SetActive(false);
    }
}
