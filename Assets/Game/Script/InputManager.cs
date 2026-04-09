using System;
using Unity.VisualScripting;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Action<Vector2> OnMoveInput;
    public Action<bool> OnSprintInput;
    public Action OnJumpInput;
    public Action OnClimbInput;
    public Action OnCancelClimb;

    private void Update()
    {
        CheckMovementInput();
        CheckSprintInput();
        CheckCrouchInput();
        CheckJumpInput();
        CheckViewChangeInput();
        CheckClimbInput();
        CheckGlideInput();
        CheckCancelInput();
        CheckHitInput();
        CheckEscapeInput();
    }

    //private void CheckMovementInput()
    //{
    //    float verticalAxis = Input.GetAxis("Vertical");
    //    float horizontalAxis = Input.GetAxis("Horizontal");
    //    Debug.Log("Vertical Axis" + verticalAxis);
    //    Debug.Log("Horizontal Axis" + horizontalAxis);
    //}

    private void CheckMovementInput()
    {
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");
        Vector2 inputAxis = new Vector2(horizontalAxis, verticalAxis);

        if (OnMoveInput != null)
        {
            OnMoveInput(inputAxis);
        }
    }

    private void CheckSprintInput()
    {
        //bool pressedSprintInput = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        bool isHoldSprintInput = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        //if (pressedSprintInput)
        //{
        //    Debug.Log("Sprint");
        //}
        //else
        //{
        //    Debug.Log("No Sprint");
        //}
        if (isHoldSprintInput)
        {
            if (OnSprintInput != null)
            {
                OnSprintInput(true);
            }
        }
        else
        {
            if (OnSprintInput != null)
            {
                OnSprintInput(false);
            }
        }
    }

    private void CheckCrouchInput()
    {
        bool pressedCrouchInput = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);
        if (pressedCrouchInput)
        {
            Debug.Log("Crouch");
        }
        else
        {
            Debug.Log("No Crouch");
        }
    }

    private void CheckJumpInput()
    {
        bool pressedJumpInput = Input.GetKeyDown(KeyCode.Space);
        if (pressedJumpInput)
        {
            //Debug.Log("Jump");
            if (OnJumpInput != null)
            {
                OnJumpInput();
            }
        }
    }

    private void CheckViewChangeInput()
    {
        bool pressedViewChangeInput = Input.GetKeyDown(KeyCode.Q);
        if (pressedViewChangeInput)
        {
            Debug.Log("Change POV");
        }
    }

    private void CheckClimbInput()
    {
        bool pressedClimbInput = Input.GetKeyDown(KeyCode.E);
        if (pressedClimbInput)
        {
            //Debug.Log("Climb");
            OnClimbInput();
        }
    }

    private void CheckGlideInput()
    {
        bool pressedGlideInput = Input.GetKeyDown(KeyCode.G);
        if (pressedGlideInput)
        {
            Debug.Log("Glide");
        }
    }

    private void CheckCancelInput()
    {
        bool pressedCancelInput = Input.GetKeyDown(KeyCode.C);
        if (pressedCancelInput)
        {
            //Debug.Log("Cancel");
            if (OnCancelClimb != null)
            {
                OnCancelClimb();
            }
        }
    }

    private void CheckHitInput()
    {
        bool pressedHitInput = Input.GetKeyDown(KeyCode.Mouse0);
        if (pressedHitInput)
        {
            Debug.Log("Hit");
        }
    }

    private void CheckEscapeInput()
    {
        bool pressedEscapeInput = Input.GetKeyDown(KeyCode.Escape);
        if (pressedEscapeInput)
        {
            Debug.Log("Back to Main Menu");
        }
    }
}
