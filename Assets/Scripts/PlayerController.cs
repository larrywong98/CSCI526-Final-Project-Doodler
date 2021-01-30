using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Animator animator;
    // public int playerId = 0;
    public GameObject crossHair;

    public GameObject arrowPrefab;

    public float speed;

    public Rigidbody2D rb;
    // private Player player;

    // Start is called before the first frame update
    
    // void Awake()
    // {
    //     player = ReInput.players.GetPlayer(playerId);
    // }

    // Update is called once per frame
    void Update()
    {
        Move();
        // AimAndShoot(0);


    }

    private void Move(){
        // rgd = GetComponent<Rigidbody>();
        Vector3 movement = new Vector3(VJoystick.joystickpos.x, VJoystick.joystickpos.y, 0.0f);

        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0){

            movement = new Vector3 (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);

        }      

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);

        // Debug.Log(movement.x);
        // Debug.Log(VJoystick.joystickpos.x);

        
        // transform.position = transform.position + movement* speed * Time.deltaTime;
        rb.velocity=new Vector2(movement.x,movement.y)*speed;
    }

    public void AimAndShoot(float test){

        
        // Vector3 aim = new Vector3(Input.GetAxis("AimHorizontal"), Input.GetAxis("AimVertical"), 0.0f);  // the location where crosshair should appear
        Vector3 aim = new Vector3(VJoystick.joystickpos.x, VJoystick.joystickpos.y, 0.0f);

        // Vector2 shootingDirection = new Vector2(Input.GetAxis("AimHorizontal"), Input.GetAxis("AimVertical")); // GET the shooting angle
        Vector2 shootingDirection = new Vector2(VJoystick.joystickpos.x, VJoystick.joystickpos.y); // GET the shooting angle
        
        if (aim.magnitude > 0.0f){

            // set the crosshair distance
            aim.Normalize();
            aim = aim * 1.4f;
            crossHair.transform.localPosition = aim;
            crossHair.SetActive(true); // activate the crosshair (since we closed it before)
            shootingDirection.Normalize();
            // if(Input.GetButtonDown("Fire")) { // the player is FIRE !!!
            if(test==1){
                GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
                arrow.GetComponent<Rigidbody2D>().velocity = shootingDirection * 3.0f; // set arrow velocity
                arrow.transform.Rotate(0.0f, 0.0f, Mathf.Atan2(-shootingDirection.y, -shootingDirection.x) * Mathf.Rad2Deg);
                Destroy(arrow, 2.0f);
            }


            }else{ // if we do not aim at something, the crosshair will not activate
                crossHair.SetActive(false); // deactivate the crosshair
            }
    }
}
