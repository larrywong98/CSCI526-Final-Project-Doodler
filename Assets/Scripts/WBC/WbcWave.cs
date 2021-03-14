using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WbcWave : MonoBehaviour
{

    public void EndAttack(){

        gameObject.SetActive(false);

        transform.eulerAngles = new Vector3(0, 0, 0);

        // VAim.attackDirection = new Vector2(0, 0);
    }
}
