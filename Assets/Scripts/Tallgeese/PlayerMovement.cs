using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveH, moveV;
    [SerializeField] private float moveSpeed;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
        moveH = Input.GetAxis("Horizontal") * moveSpeed;
        moveV = Input.GetAxis("Vertical") * moveSpeed;
        Flip();
    }



    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveH, moveV);
    }


    private void Flip()
    {
        if (moveH > 0)
            transform.eulerAngles = new Vector3(0, 0, 0);
        if (moveH < 0)
            transform.eulerAngles = new Vector3(0, 180, 0);

    }




}
