using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveEffect : MonoBehaviour {

    [SerializeField] private Material material;

    private float disAmount;
    private float disSpeed;
    private bool isDissolving;

    private void Start() {
        // if (material == null) {
        //     material = transform.Find("Body").GetComponent<MeshRenderer>().material;
        // }
    }

    private void Update() {
        if (isDissolving) {
            disAmount = Mathf.Clamp01(disAmount + disSpeed * Time.deltaTime);
            material.SetFloat("_DissolveAmount", disAmount);
        } else {
            disAmount = Mathf.Clamp01(disAmount - disSpeed * Time.deltaTime);
            material.SetFloat("_DissolveAmount", disAmount);
        }
    }

    public void Dissolve(float dispeed, Color discolor) {
        isDissolving = true;
        material.SetColor("_DissolveColor", discolor);
        disSpeed = dispeed;
    }

    public void AntiDissolve(float dispeed, Color discolor) {
        isDissolving = false;
        material.SetColor("_DissolveColor", discolor);
        disSpeed = dispeed;
    }

}
