using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController_Daniel : MonoBehaviour
{

    PlayerControls control;
    Vector2 move;
    CharacterController player;

    void Awake()
    {
        control = new PlayerControls();
        player = GetComponent<CharacterController>();

        control.Movement.Walk.performed += ctx => move = ctx.ReadValue<Vector2>();
        //control.Movement.Walk.canceled += ctx => move = Vector2.zero;
    }

    private void OnEnable()
    {

        control.Movement.Enable();

    }

    private void OnDisable()
    {
        control.Movement.Disable();
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
        player.Move(new Vector3(move.x, 0, move.y)*Time.deltaTime);
        Rotation();

    }
}
