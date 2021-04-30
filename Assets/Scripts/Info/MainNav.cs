using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainNav: MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;

    public void page1()
    {
        FullControl.panelid=1;
    	panel1.SetActive(true);
    	panel2.SetActive(false);
    	panel3.SetActive(false);
    }

    public void page2()
    {
        FullControl.panelid=2;
    	panel1.SetActive(false);
    	panel2.SetActive(true);
    	panel3.SetActive(false);
    }

    public void page3()
    {
        FullControl.panelid=3;
    	panel1.SetActive(false);
    	panel2.SetActive(false);
    	panel3.SetActive(true);
    }
}

