using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing_Dissolve : MonoBehaviour {

    [SerializeField] private DissolveEffect dissolveEffect;
    // [ColorUsageAttribute(true, true)]
    [SerializeField] private Color disappearColor;
    // [ColorUsageAttribute(true, true)]
    [SerializeField] private Color reappearColor;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.J)) {
            dissolveEffect.Dissolve(0.7f, disappearColor);
            Debug.Log("ok");
        }
        if (Input.GetKeyDown(KeyCode.K)) {
            dissolveEffect.AntiDissolve(0.7f, reappearColor);
        }
    }

}
