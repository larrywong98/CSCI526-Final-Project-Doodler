using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Rigidbody2D))]
public class WbcMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveH, moveV;
    [SerializeField] private float moveSpeed;
    public Animator animator;
    
    public bool NormalMovement { get; set; }
    public Vector3 CurrentMovement { get; set; }


    // Start is called before the first frame update
    void Start()
    {
        NormalMovement = true;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (NormalMovement)
        {
            MoveCharacter();
        }
    }

    private void Flip()
    {
        if (moveH > 0)
            transform.eulerAngles = new Vector3(0, 180, 0);
        if (moveH < 0)
            transform.eulerAngles = new Vector3(0, 0, 0);
    }

    public void MoveCharacter()
    {
        // moveH = VJoystick.joystickpos.x* moveSpeed;
        // moveV = VJoystick.joystickpos.y* moveSpeed;
        moveH = Input.GetAxis("Horizontal") * moveSpeed;
        moveV = Input.GetAxis("Vertical") * moveSpeed;
        // Vector3 movement = new Vector3 (VJoystick.joystickpos.x,VJoystick.joystickpos.y, -1f);
        Vector3 movement = new Vector3 (Input.GetAxis("Horizontal"),Input.GetAxis("Vertical") , -1f);
        CurrentMovement = movement;
        animator.SetFloat("Magnitude", movement.magnitude);
        Flip();
        rb.velocity = new Vector2(moveH, moveV);
    }

    public void SetMovement(Vector3 newPosition)
    {
        CurrentMovement = newPosition;
    }

    public void MovePosition(Vector2 newPosition)
    {
        rb.MovePosition(newPosition);
    }
}
