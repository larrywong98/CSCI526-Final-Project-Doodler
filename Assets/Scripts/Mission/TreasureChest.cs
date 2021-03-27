using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TreasureChest : MonoBehaviour
{
    private GameObject[] obj=new GameObject[100];
    private Image[] image=new Image[100];
    private Sprite chestSprite;
    // public static int[] FullControl.canOpen=new int[100]; 
    // public static int[] FullControl.isOpen=new int[100];
    // public int countChest=0;
    public int isfirst=1;
    private Button[] chestOpen=new Button[100];
    public static int[] enterOnce=new int[100];
    public int initOnce;
    public Text glucoseText;

    public void Start(){
        // status=GameObject.FindGameObjectsWithTag("requeststatus");
        if(initOnce==0){
            for(int i=1;i<100;i++){
                FullControl.canOpen[i]=0;
                FullControl.isOpen[i]=0;
            }
            for(int i=1;i<100;i++){
                enterOnce[i]=0;
            }
        }
        glucoseText=GameObject.FindGameObjectWithTag("showglucose").GetComponent<Text>();

    }
    public void StartRequest() {
        // countChest=1;
        // Debug.Log("okkkkkk");
        
        if(transform.childCount==0){
            isfirst=0;
            return;
        }
        obj=GameObject.FindGameObjectsWithTag("requeststatus");
        for(int i=0;i<transform.childCount;i++){
            image[i]=obj[i].GetComponent<Image>();
            chestOpen[i]=obj[i].GetComponent<Button>();
            int spriteid;
            if(FullControl.isOpen[i]==1){
                spriteid=i*3+3;
            }else{
                spriteid=i*3+1;
            }
            string path="mission/"+spriteid;
            chestSprite = Resources.Load(path,typeof(Sprite)) as Sprite;
            //改变图片
            image[i].sprite = chestSprite;
        }
    }
    private void Update() {
        // for(int i=0;i<transform.childCount;i++){
        
            for(int i=0;i<transform.childCount;i++){
                if(FullControl.canOpen[i]==1 && FullControl.isOpen[i]==0){
                    if(enterOnce[i]==0){
                        int y=i;
                        chestOpen[i].onClick.AddListener(()=>ChangeToOpen(y));
                        int spriteid=i*3+2;
                        string path="mission/"+spriteid;
                        chestSprite = Resources.Load(path,typeof(Sprite)) as Sprite;
                        //改变图片
                        image[i].sprite = chestSprite;
                    }
                }
            }
      
    }
    public void ChangeToOpen(int i){
            // Debug.Log(i);
        // if(FullControl.canOpen[i]==1){
        
        int spriteid=i*3+3;
        string path="mission/"+spriteid;
        chestSprite = Resources.Load(path,typeof(Sprite)) as Sprite;
        //改变图片
        image[i].sprite = chestSprite;
        if(enterOnce[i]==0){
            FullControl.glucose=FullControl.glucose+(i+1)*5;
            glucoseText.text="  "+FullControl.glucose;
            enterOnce[i]=1;
        }
        FullControl.canOpen[i]=0;
        FullControl.isOpen[i]=1;
        chestOpen[i]=null;
        
        
        
        // }
    }
}
