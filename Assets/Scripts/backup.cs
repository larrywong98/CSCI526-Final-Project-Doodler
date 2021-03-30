
    // public Transform target;
    // public float speed =20f;
    // public float nextWaypointdist=3f;
    // Path path;
    // int currentWaypoint=0;
    // BOOL reachedEndOfPath=false;
    // Seeker seeker;
    // Rigidbody2D rb;
    // void Start(){
    //     seeker=GetComponent<Seeker>();
    //     rb=GetComponent<Rigidbody2D>();
    //     InvokeRepeating("UpdatePath",0f,.5f);
    // }
    // void UpdatePath(){
    //     if(seeker.IsDone()){
    //         seeker.StartPath(rb.position,target.position,OnPathComplete);
    //     }
    // }
    // void OnPathComplete(Path p){
    //     if(!p.error){
    //         path=p;
    //         currentWaypoint=0;
    //     }
    // }
    // void FixedUpdate(){
    //     if(path==null)
    //     return;
    //     if(currentWaypoint>=path.vectorPath.Count){
    //         reachedEndOfPath=true;
    //     }else{
    //         reachedEndOfPath=false;
    //     }
    //     Vector2 direction=((Vector2)path.vectorPath[currentWaypoint]-rb.position).normalized;
    //     Vector2 force=direction*speed*Time.deltaTime;
    //     rb.AddForce(force);
    //     float distance=Vector2.Distance(rb.position,path.vectorPath[currentWaypoint]);
    //     if(distance<nextWaypointdist){
    //         currentWaypoint++;
    //     }
    // }



//     using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.EventSystems;

// public class tolevel2 : MonoBehaviour
// {
//     public Animator fade;
//     public float transitionTime=1f;
//     private Transform target;
//     private void Start() {
//         target=GameObject.FindGameObjectWithTag("character").GetComponent<Transform>();
//     }
//     private IEnumerator waitLoad(){
//         yield return new WaitForSeconds(transitionTime); 
//         Loader.Load(Loader.Scene.Level2);
//     }
//     private void Update() 
//     {
//         // Debug.Log(target.position);
//         if(target.position.x<=-18.5 && target.position.x>=-20.5 &&
//            target.position.y>=-1.5 && target.position.y<=1)
//         {
//             fade.SetTrigger("out");
//             StartCoroutine(waitLoad());
//         }
//     }
// }


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;



// [RequireComponent(typeof(Rigidbody2D))]
// public class PlayerMovement : MonoBehaviour
// {
//     private Rigidbody2D rb;
//     private float moveH, moveV;
//     [SerializeField] private float moveSpeed;


//     // Start is called before the first frame update
//     void Start()
//     {
//         rb = GetComponent<Rigidbody2D>();


//     }

//     // Update is called once per frame
//     void Update()
//     {
//         moveH = Input.GetAxis("Horizontal") * moveSpeed;
//         moveV = Input.GetAxis("Vertical") * moveSpeed;
//         Flip();
//     }



//     private void FixedUpdate()
//     {
//         rb.velocity = new Vector2(moveH, moveV);
//     }


//     private void Flip()
//     {
//         if (moveH > 0)
//             transform.eulerAngles = new Vector3(0, 0, 0);
//         if (moveH < 0)
//             transform.eulerAngles = new Vector3(0, 180, 0);

//     }




// }


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerController : MonoBehaviour
// {

//     // public Animator animator;
//     // public int playerId = 0;
//     // public GameObject crossHair;

//     // public GameObject arrowPrefab;

//     public float speed;

//     public Rigidbody2D rb;
//     // private Player player;

//     // Start is called before the first frame update
    
//     // void Awake()
//     // {
//     //     player = ReInput.players.GetPlayer(playerId);
//     // }

    // private void Flip()
    // {
    //     if (VJoystick.joystickpos.x > 0)
    //         transform.eulerAngles = new Vector3(0, 0, 0);
    //     if (VJoystick.joystickpos.x < 0)
    //         transform.eulerAngles = new Vector3(0, 180, 0);

    // }
    // void Update()
    // {
    //     Flip();
    // }

    // // Update is called once per frame
    // void FixedUpdate()
    // {
    //     // Move();
    //     // AimAndShoot(0);
    //     rb.velocity=new Vector2(VJoystick.joystickpos.x,VJoystick.joystickpos.y)*speed;


    // }

    // private void Move(){
    //     // rgd = GetComponent<Rigidbody>();
    //     Vector3 movement = new Vector3(VJoystick.joystickpos.x, VJoystick.joystickpos.y, 0.0f);

    //     if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0){

    //         movement = new Vector3 (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);

    //     }      

    //     // animator.SetFloat("Horizontal", movement.x);
    //     // animator.SetFloat("Vertical", movement.y);
    //     // animator.SetFloat("Magnitude", movement.magnitude);

    //     // Debug.Log(movement.x);
    //     // Debug.Log(VJoystick.joystickpos.x);

        
    //     // transform.position = transform.position + movement* speed * Time.deltaTime;
    //     rb.velocity=new Vector2(movement.x,movement.y)*speed;
    //     // Debug.Log(transform.position);
    // }

    // public void AimAndShoot(float test){

        
    //     // Vector3 aim = new Vector3(Input.GetAxis("AimHorizontal"), Input.GetAxis("AimVertical"), 0.0f);  // the location where crosshair should appear
    //     Vector3 aim = new Vector3(VJoystick.joystickpos.x, VJoystick.joystickpos.y, 0.0f);

    //     // Vector2 shootingDirection = new Vector2(Input.GetAxis("AimHorizontal"), Input.GetAxis("AimVertical")); // GET the shooting angle
    //     Vector2 shootingDirection = new Vector2(VJoystick.joystickpos.x, VJoystick.joystickpos.y); // GET the shooting angle
        
    //     if (aim.magnitude > 0.0f){

    //         // set the crosshair distance
    //         aim.Normalize();
    //         aim = aim * 1.4f;
    //         crossHair.transform.localPosition = aim;
    //         crossHair.SetActive(true); // activate the crosshair (since we closed it before)
    //         shootingDirection.Normalize();
    //         // if(Input.GetButtonDown("Fire")) { // the player is FIRE !!!
    //         if(test==1){
    //             GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
    //             arrow.GetComponent<Rigidbody2D>().velocity = shootingDirection * 3.0f; // set arrow velocity
    //             arrow.transform.Rotate(0.0f, 0.0f, Mathf.Atan2(-shootingDirection.y, -shootingDirection.x) * Mathf.Rad2Deg);
    //             Destroy(arrow, 2.0f);
    //         }


    //         }else{ // if we do not aim at something, the crosshair will not activate
    //             crossHair.SetActive(false); // deactivate the crosshair
    //         }
    // }
   
// }


   // private void LateUpdate(){

        



    //     VAim.attackDirection = new Vector2(0, 0);
    // } 

    // private void Flip()
    // {
        // if (VJoystick.joystickpos.x > 0)
        //     transform.eulerAngles = new Vector3(0, 180, 0);
        // if (VJoystick.joystickpos.x < 0)
        //     transform.eulerAngles = new Vector3(0, 0, 0);
        
        
        
        // if (VAim.isAttackButtionUp == 1){
        //     if(VAim.attackDirection.x >= 0){
        //         transform.eulerAngles = new Vector3(0, 180, 0);
        //     }
        //     if(VAim.attackDirection.x < 0){
        //         transform.eulerAngles = new Vector3(0, 0, 0);
        //     }

        // }else{

        //     if (moveH > 0)
        //         transform.eulerAngles = new Vector3(0, 180, 0);
        //     if (moveH < 0)
        //         transform.eulerAngles = new Vector3(0, 0, 0);
        // }
        

    // }