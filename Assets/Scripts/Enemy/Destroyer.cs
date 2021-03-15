using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private float lifeTimer;
    void Start()
    {
        Destroy(gameObject, lifeTimer);
    }

}
