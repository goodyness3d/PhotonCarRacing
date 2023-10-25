using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class TheInputHandler : MonoBehaviour
{
    [Header("Character Input Values")]
    public Vector2 move;
    public Vector2 look;
    public bool throttle;
    public bool brake;
    public bool handbrake;
    public bool left;
    public bool right;

    [Header("Movement Settings")]
    public bool analogMovement;

    [Header("Look Settings")]
    [HideInInspector] public float lookSensitivity = 1f;
    public float normalLookSensitivity;
    public float aimLookSensitivity;

    [Header("Mouse Cursor Settings")]
    public bool cursorLocked = true;
    public bool cursorInputForLook = true;

    //[Header("Shooting Settings")]
    //public bool holdToAim = true;



    private void OnEnable()
    {
        SetCursorState(cursorLocked);
    }



    // THE INPUT MESSAGES RECEIVED FROM THE PLAYER INPUT OF THE NEW INPUT SYSTEM

    private void OnApplicationFocus(bool hasFocus)
    {
        //SetCursorState(cursorLocked);
    }

    private void SetCursorState(bool newState)
    {
        Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
    }
    public void OnMove(InputValue value)
    {
        MoveInput(value.Get<Vector2>());
    }

    public void OnLook(InputValue value)
    {
        if (cursorInputForLook)
        {
            LookInput(value.Get<Vector2>());
        }
    }

    public void OnThrottle(InputValue value)
    {
        ThrottleInput(value.isPressed);
    }

    public void OnBrake(InputValue value)
    {
        BrakeInput(value.isPressed);
    }

    public void OnHandbrake(InputValue value)
    {
        HandbrakeInput(value.isPressed);
    }

    public void OnLeft(InputValue value)
    {
        LeftInput(value.isPressed);
    }

    public void OnRight(InputValue value)
    {
        RightInput(value.isPressed);
    }



    // THE FUNCTIONS CALLED BY THE ABOVE MESSAGES

    public void MoveInput(Vector2 newMoveDirection)
    {
        move = newMoveDirection;
    }

    public void LookInput(Vector2 newLookDirection)
    {
        look = newLookDirection;
    }

    public void ThrottleInput(bool newThrottleState)
    {
        throttle = newThrottleState;
    }

    public void BrakeInput(bool newBrakeState)
    {
        brake = newBrakeState;
    }

    public void HandbrakeInput(bool newHandbrakeState)
    {
        handbrake = newHandbrakeState;
    }

    public void LeftInput(bool newLeftState)
    {
        left = newLeftState;
    }

    public void RightInput(bool newRightState)
    {
        right = newRightState;
    }
}
