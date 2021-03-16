using UnityEngine;
using System.Collections;
 
public class DestroyObj : MonoBehaviour {
    public float Duration = 0.4f;
    public CanvasGroup canvGroup;

    void Start()
    {
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
    }
 
}
