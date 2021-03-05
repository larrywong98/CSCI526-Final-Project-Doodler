using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TreasureChest : MonoBehaviour
{
    private GameObject[] obj=new GameObject[100];
    private Image[] image=new Image[100];
    private Sprite chestSprite;
    public static int[] canOpen=new int[100]; 
    // public int countChest=0;
    public int isfirst=1;
    private Button[] chestOpen=new Button[100];
    public static int flag=0;
    // public int openid=0;
    // public void treasure(string count){

    // }
    public void Start(){
        // status=GameObject.FindGameObjectsWithTag("requeststatus");
        for(int i=0;i<100;i++){
            canOpen[i]=1;
            // chestOpen[i]=status[i].GetComponent<Button>();
        }

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
            int spriteid=i*3+1;
            string path="mission/"+spriteid;
            // Debug.Log(path);
            chestSprite = Resources.Load(path,typeof(Sprite)) as Sprite;
            //改变图片
            image[i].sprite = chestSprite;
        }
    }
    private void Update() {
        // for(int i=0;i<transform.childCount;i++){
        if(flag==0){
            for(int i=0;i<transform.childCount;i++){
                if(canOpen[i]==1){
                    // Debug.Log(i);
                    int y=i;
                    chestOpen[i].onClick.AddListener(()=>ChangeToOpen(y));
                    // openid=openid+1;
                    int spriteid=i*3+2;
                    string path="mission/"+spriteid;
                    // Debug.Log(path);
                    chestSprite = Resources.Load(path,typeof(Sprite)) as Sprite;
                    //改变图片
                    image[i].sprite = chestSprite;
                }
            }
            // countChest=countChest+1;
            flag=1;
        }
        // }
    }
    public void ChangeToOpen(int i){
            // Debug.Log(i);
        // if(canOpen[i]==1){
        int spriteid=i*3+3;
        string path="mission/"+spriteid;
        // Debug.Log(path);
        chestSprite = Resources.Load(path,typeof(Sprite)) as Sprite;
        //改变图片
        image[i].sprite = chestSprite;
        canOpen[i]=0;
        chestOpen[i]=null;
        // }
    }
    public void EndRequest(){
        if(isfirst==0) return;
       
        isfirst=0;
        
        // image.color=new Color(image.color.r,image.color.g,image.color.b,1f);

    }
}
