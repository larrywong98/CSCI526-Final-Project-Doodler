using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class next : MonoBehaviour
{

    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;
    public GameObject panel5;
    public GameObject panel6;
    public GameObject panel7;
    public GameObject panel8;
    public GameObject panel9;
    public GameObject panel10;
    public int count=0;
    public int prev=0;
    public void click(){
        if(prev!=FullControl.panelid){
            prev=FullControl.panelid;
            count=0;
        }
        count=count+1;
        if(count==4)count=0;
        page();
    }
    public void page(){
        if(count==0)
        page1();
        if(count==1)
        page2();
        if(count==2)
        page3();
        if(count==3)
        page4();
        
    }
    public void page1()
    {
        if(FullControl.panelid==1){
            panel1.SetActive(true);
            panel2.SetActive(false);
            panel3.SetActive(false);
            panel4.SetActive(false);
        }
        if(FullControl.panelid==2){
            panel5.SetActive(true);
            panel6.SetActive(false);
        }
    	if(FullControl.panelid==3){
            panel7.SetActive(true);
            panel8.SetActive(false);
            panel9.SetActive(false);
            panel10.SetActive(false);
        }
    }

    public void page2()
    {
        if(FullControl.panelid==1){
            panel1.SetActive(false);
            panel2.SetActive(true);
            panel3.SetActive(false);
            panel4.SetActive(false);
        }
        if(FullControl.panelid==2){
            panel5.SetActive(false);
            panel6.SetActive(true);
        }
        if(FullControl.panelid==3){
            panel7.SetActive(false);
            panel8.SetActive(true);
            panel9.SetActive(false);
            panel10.SetActive(false);
        }
    }

    public void page3()
    {
        if(FullControl.panelid==1){
    	panel1.SetActive(false);
    	panel2.SetActive(false);
    	panel3.SetActive(true);
        panel4.SetActive(false);
        }
        if(FullControl.panelid==3){
            panel7.SetActive(false);
            panel8.SetActive(false);
            panel9.SetActive(true);
            panel10.SetActive(false);
        }
    }
    public void page4()
    {
        if(FullControl.panelid==1){
            panel1.SetActive(false);
            panel2.SetActive(false);
            panel3.SetActive(false);
            panel4.SetActive(true);
        }
        if(FullControl.panelid==3){
            panel7.SetActive(false);
            panel8.SetActive(false);
            panel9.SetActive(false);
            panel10.SetActive(true);
        }
    }
}