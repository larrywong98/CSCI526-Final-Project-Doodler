using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNav : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;

    public void page1()
    {
    	panel1.SetActive(true);
    	panel2.SetActive(false);
        panel3.SetActive(false);
    	panel4.SetActive(false);
    }

    public void page2()
    {
    	panel1.SetActive(false);
    	panel2.SetActive(true);
        panel3.SetActive(false);
    	panel4.SetActive(false);
    }
    public void page3()
    {
    	panel1.SetActive(false);
    	panel2.SetActive(false);
        panel3.SetActive(true);
    	panel4.SetActive(false);
    }
    public void page4()
    {
    	panel1.SetActive(false);
    	panel2.SetActive(false);
        panel3.SetActive(false);
    	panel4.SetActive(true);
    }
}