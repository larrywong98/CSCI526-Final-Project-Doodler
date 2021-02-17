using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageNum : MonoBehaviour
{

    public Text damageText;
    public float lifeTimer;
    public float upSpeed;
    // public Transform target;
    // public float smoothspeed;

    // Start is called before the first frame update
    void Start()
    {
        // target=GameObject.FindGameObjectWithTag("character").GetComponent<Transform>();
        Destroy(gameObject, lifeTimer);
        
    }
    // private void LateUpdate() {
    //     transform.position=Vector3.Lerp(
    //         transform.position,new Vector3(target.position.x,target.position.y,-10),
    //         smoothspeed * Time.deltaTime);
     
    // }
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, upSpeed * Time.deltaTime, 0);
        
    }

    public void ShowUIDamage(float _amount){
        damageText.text = _amount.ToString();
    }
}
