using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Rigidbody2D))]
public class WbcMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveH, moveV;
    private float moveSpeed;
    public Animator animator;
    

    private bool NormalMovement;// { get; set; }
    private Vector3 CurrentMovement;// { get; set; }
    [SerializeField] private float dashDistance = 5f;
    [SerializeField] private float dashDuration = 0.5f;
    private bool isDashing;
    private float dashTimer;
    private Vector2 dashOrigin;
    private Vector2 dashDestination;
    private Vector2 newPosition;
    public static int crashes=0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed=FullControl.mainCharacterMoveSpeed;
        NormalMovement = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       if (NormalMovement)
        {
            NormalMoveCharacter();
        }
        
        if (isDashing)
        {
            if(crashes==1){
                isDashing=false;
                NormalMovement =true;
                crashes=0;
                return;
            }
            if (dashTimer < dashDuration)
            {
                newPosition = Vector2.Lerp(dashOrigin, dashDestination, dashTimer / dashDuration);
                rb.MovePosition(newPosition);
                dashTimer += Time.deltaTime;
            }
            else
            {
                StopDash();
            }
        }
        
    }
    public void HandleAbility()
    {
        Dash();
    }

    private void Dash()
    {
        isDashing = true;
        dashTimer = 0f;
        NormalMovement = false;
        dashOrigin = transform.position;
        dashDestination = (Vector3) dashOrigin + (Vector3) CurrentMovement.normalized * dashDistance;
    }

    private void StopDash()
    {
        isDashing = false;
        NormalMovement = true;
    }
    private void Flip()
    {
        if (moveH > 0)
            transform.eulerAngles = new Vector3(0, 180, 0);
        if (moveH < 0)
            transform.eulerAngles = new Vector3(0, 0, 0);
    }
    void NormalMoveCharacter(){
        if(VJoystick.joystickpos.x != 0 || VJoystick.joystickpos.y!=0 ){
            moveH = VJoystick.joystickpos.x* moveSpeed;
            moveV = VJoystick.joystickpos.y* moveSpeed;
        }else{
            moveH = Input.GetAxis("Horizontal") * moveSpeed;
            moveV = Input.GetAxis("Vertical") * moveSpeed;
        }
        

        Vector3 movement = new Vector3 (moveH, moveV, 0f);
        // Vector3 movement = new Vector3 (Input.GetAxis("Horizontal"),Input.GetAxis("Vertical") , -1f);
        CurrentMovement = movement;
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("AttackDirection", VAim.attackDirection.x);
        animator.SetFloat("Magnitude", movement.magnitude);
        // Flip();
        rb.velocity = new Vector2(moveH, moveV);

        // IDLE时若有attackdirection则转向并清零
        if(movement.x == moveSpeed || movement.x == -moveSpeed){

            animator.SetFloat("LastMoveX", movement.x);
        }
    }


 

}
