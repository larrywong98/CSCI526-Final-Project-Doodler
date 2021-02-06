using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camcontroller : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float smoothspeed;
    [SerializeField] private float minx,miny,maxx,maxy;
    private void Start()
    {
        target=GameObject.FindGameObjectWithTag("character").GetComponent<Transform>();
    }
    private void LateUpdate() {
        // transform.position=new Vector3(target.position.x,target.position.y,-10);
        transform.position=Vector3.Lerp(
            transform.position,new Vector3(target.position.x,target.position.y,-10),
            smoothspeed * Time.deltaTime);
        transform.position=new Vector3(Mathf.Clamp(transform.position.x,minx,maxx),
                                        Mathf.Clamp(transform.position.y,miny,maxy),
                                        transform.position.z);
    }
    public IEnumerator CameraShakeCo(float _maxTime, float _amount)
    {
        Vector3 originalPos = transform.localPosition;
        float shakeTime = 0.0f;

        while(shakeTime < _maxTime)
        {
            float x = Random.Range(-1f, 1f) * _amount;
            float y = Random.Range(-1f, 1f) * _amount;

            transform.localPosition = new Vector3(x, y, originalPos.z);
            shakeTime += Time.deltaTime;

            yield return new WaitForSeconds(0f);
        }
    }
}
