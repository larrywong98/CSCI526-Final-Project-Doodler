using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfferRequest : MonoBehaviour
{
    private Transform requestTransform;
    [SerializeField] private GameObject quest;
    // Start is called before the first frame update
    void Start()
    {
        requestTransform=GameObject.FindGameObjectWithTag("request").GetComponent<Transform>();
        GameObject tmp=Instantiate(quest, new Vector3(0f,0f,0f), Quaternion.identity);
        tmp.transform.parent=requestTransform;
        // Instantiate(quest, requestTransform, Quaternion.identity);
        // Instantiate(quest, requestTransform, Quaternion.identity);
        // Instantiate(quest, requestTransform, Quaternion.identity);
        // Instantiate(quest, requestTransform, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
