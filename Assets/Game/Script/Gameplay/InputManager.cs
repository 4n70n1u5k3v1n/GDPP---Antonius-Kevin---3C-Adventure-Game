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
    public Action OnChangePOV;
    public Action OnCrouchInput;
    public Action OnGlideInput;
    public Action OnCancelGlide;
    public Action OnPunchInput;
    public Action OnMainMenuInput;

    private void Update()
    {
        CheckMovementInput();
        CheckSprintInput();
        CheckCrouchInput();
        CheckJumpInput();
        CheckClimbInput();
        CheckGlideInput();
        CheckCancelInput();
        CheckPunchInput();
        CheckMainMenuInput();
        CheckChangePOVInput();
    }

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
        bool isHoldSprintInput = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

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
        bool pressedCrouchInput = Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl);
        if (pressedCrouchInput)
        {
            OnCrouchInput();
        }
    }

    private void CheckJumpInput()
    {
        bool pressedJumpInput = Input.GetKeyDown(KeyCode.Space);
        if (pressedJumpInput)
        {
            if (OnJumpInput != null)
            {
                OnJumpInput();
            }
        }
    }

    private void CheckClimbInput()
    {
        bool pressedClimbInput = Input.GetKeyDown(KeyCode.E);
        if (pressedClimbInput)
        {
            OnClimbInput();
        }
    }

    private void CheckGlideInput()
    {
        bool pressedGlideInput = Input.GetKeyDown(KeyCode.G);
        if (pressedGlideInput)
        {
            if (OnGlideInput != null)
            {
                OnGlideInput();
            }
        }
    }

    private void CheckCancelInput()
    {
        bool pressedCancelInput = Input.GetKeyDown(KeyCode.C);
        if (pressedCancelInput)
        {
            if (OnCancelClimb != null)
            {
                OnCancelClimb();
            }
            if (OnCancelGlide != null)
            {
                OnCancelGlide();
            }
        }
    }

    private void CheckPunchInput()
    {
        bool pressedPunchInput = Input.GetKeyDown(KeyCode.Mouse0);
        if (pressedPunchInput)
        {
            OnPunchInput();
        }
    }

    private void CheckMainMenuInput()
    {
        bool isPressMainMenuInput = Input.GetKeyDown(KeyCode.Escape);

        if (isPressMainMenuInput)
        {
            if (OnMainMenuInput != null)
            {
                OnMainMenuInput();
            }
        }
    }

    private void CheckChangePOVInput()
    {
        bool isPressChangePOVInput = Input.GetKeyDown(KeyCode.Q);

        if (isPressChangePOVInput)
        {
            if (OnChangePOV != null)
            {
                OnChangePOV();
            }
        }
    }
}
