using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController_Daniel : MonoBehaviour
{

    
    Vector2 move;
    public Vector3 velocity;
    float gravity = -9.81f;
    public bool isGrounded;
    public bool rightHandGrab;
    public GameObject groundC;
    public LayerMask ground;
    public LayerMask objects;
    CharacterController player;
    PlayerControls control;
    Transform armature;
    Transform hips;
    public Transform righthandpos;
    Transform lefthandpos;
    Rigidbody rightHand;
    Rigidbody leftHAnd;
    Rigidbody hipsr;

    void Awake()
    {
        control = new PlayerControls();
        player = GetComponent<CharacterController>();
        armature = transform.GetChild(0);
        hips = armature.GetChild(0);
        hipsr = hips.GetComponent<Rigidbody>();

        rightHand = GameObject.Find("RightGrab").GetComponent<Rigidbody>();
        rightHand = GameObject.Find("LeftGrab").GetComponent<Rigidbody>();

        control.Movement.Walk.performed += ctx => move = ctx.ReadValue<Vector2>();
        control.Movement.Jump.performed += ctx => Jump();
        control.Movement.Grab.performed += ctx => Grab();
        
    }

    private void OnEnable()
    {
        control.Movement.Enable();
    }

    private void OnDisable()
    {
        control.Movement.Disable();
    }

    void Jump() 
    {

        if (isGrounded == true)
        {
            velocity.y = Mathf.Sqrt((2f * -2f * gravity));
            isGrounded = false;
            hipsr.AddForce(new Vector3(0, 6000, 0));
        }

    }

    void Move()
    {
        
        hipsr.AddForce(new Vector3(move.x*60, 0, move.y*60));
    }

    void Grab()
    {

        rightHandGrab = Physics.CheckSphere(righthandpos.transform.position, 1.0f, objects);
        if (rightHandGrab==true)
        {
            Debug.Log("GRab");
        }

    }

    void Rotation()
    {

        Vector3 currentPos = transform.position;

        Vector3 newPos = new Vector3(move.x, 0, move.y);
        Vector3 positionLook = newPos + currentPos;

        transform.LookAt(positionLook);

    }

    // Update is called once per frame
    void Update()
    {
        
        Rotation();
        isGrounded = Physics.CheckSphere(groundC.transform.position, 0.4f,ground);

    }
}
