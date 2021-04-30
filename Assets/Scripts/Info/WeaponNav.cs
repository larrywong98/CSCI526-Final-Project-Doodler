using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponNav : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;

    public void page1()
    {
    	panel1.SetActive(true);
    	panel2.SetActive(false);
    }

    public void page2()
    {
    	panel1.SetActive(false);
    	panel2.SetActive(true);
    }
}