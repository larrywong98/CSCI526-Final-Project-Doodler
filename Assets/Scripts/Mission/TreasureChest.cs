using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TreasureChest : MonoBehaviour
{
    [SerializeField] private Image image;
    private Sprite chestSprite;
    // public void treasure(string count){

    // }
    public void EndRequest(int countChest){
        // image=GameObject.GetComponent()<>();
        string path="mission/chest_"+countChest;
        chestSprite = Resources.Load(path, typeof(Sprite)) as Sprite;
        //改变图片
        image.sprite = chestSprite;
        // image.color=new Color(image.color.r,image.color.g,image.color.b,1f);

    }
}
