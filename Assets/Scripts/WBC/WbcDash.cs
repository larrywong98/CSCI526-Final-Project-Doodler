using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WbcDash : MonoBehaviour
{
    [SerializeField] private float dashDistance = 5f;
    [SerializeField] private float dashDuration = 0.5f;

    private bool isDashing;
    private float dashTimer;
    private Vector2 dashOrigin;
    private Vector2 dashDestination;
    private Vector2 newPosition;

    protected WbcMovement wbcMovement;
    
    // Start is called before the first frame update
    void Start()
    {
        wbcMovement = GetComponent<WbcMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandleAbility();
    }

    protected void HandleAbility()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Dash();
        }

        if (isDashing)
        {
            if (dashTimer < dashDuration)
            {
                newPosition = Vector2.Lerp(dashOrigin, dashDestination, dashTimer / dashDuration);
                wbcMovement.MovePosition(newPosition);
                dashTimer += Time.deltaTime;
            }
            else
            {
                StopDash();
            }
        }
    }

    
    private void Dash()
    {
        isDashing = true;
        dashTimer = 0f;
        wbcMovement.NormalMovement = false;
        dashOrigin = transform.position;

        dashDestination = (Vector3) dashOrigin + (Vector3) wbcMovement.CurrentMovement.normalized * dashDistance;
    }

    private void StopDash()
    {
        isDashing = false;
        wbcMovement.NormalMovement = true;
    }
    
}
