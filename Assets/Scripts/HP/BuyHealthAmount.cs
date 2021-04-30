using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyHealthAmount : MonoBehaviour
{
    // Start is called before the first frame update
    public Text countText;
    int count;
   	
   	public void Increase(){
   		count = int.Parse(countText.text);
   		count++;
   		countText.text = "" + count;
   	}

   	public void Decrease(){
   		count = int.Parse(countText.text);
   		count--;
   		if(count<0){
   			count=0;
   		}
   		countText.text = "" + count;
   	}
}
