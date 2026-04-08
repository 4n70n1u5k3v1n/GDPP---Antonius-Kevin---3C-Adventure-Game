using System;
using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float _walkSpeed;
    [SerializeField] private InputManager _input;
    [SerializeField] private float _rotationSmoothTime = 0.1f;
    private float _rotationSmoothVelocity;
    [SerializeField] private float _sprintSpeed;
    [SerializeField] private float _walkSprintTransition;
    private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Transform _groundDetector;

    [SerializeField] private float _detectorRadius;

    [SerializeField] private LayerMask _groundLayer;
    private bool _isGrounded;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _speed = _walkSpeed;
    }

    private void Start()
    {
        _input.OnMoveInput += Move;
        _input.OnSprintInput += Sprint;
        _input.OnJumpInput += Jump;
    }

    private void Update()
    {
        CheckIsGrounded();
    }

    private void Move(Vector2 axisDirection)
    {
        if (axisDirection.magnitude >= 0.1)
        {
            float rotationAngle = Mathf.Atan2(axisDirection.x, axisDirection.y) * Mathf.Rad2Deg;
            float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationAngle, ref _rotationSmoothVelocity, _rotationSmoothTime);
            transform.rotation = Quaternion.Euler(0f, smoothAngle, 0f);
            //Vector3 movementDirection = new Vector3(axisDirection.x, 0, axisDirection.y);
            Vector3 movementDirection = Quaternion.Euler(0f, rotationAngle, 0f) * Vector3.forward;
            //Debug.Log(movementDirection);
            _rigidbody.AddForce(movementDirection * _speed * Time.deltaTime);
        }
    }

    private void Sprint(bool isSprint)
    {
        Debug.Log("in sprint function");
        if (isSprint)
        {
            Debug.Log("speed" +_speed);
            Debug.Log("sprint speed: " + _sprintSpeed);
            Debug.Log("alkspeed" +_walkSpeed);
            if (_speed < _sprintSpeed)
            {
                Debug.Log("in sprint if if");
                _speed = _speed + _walkSprintTransition * Time.deltaTime;
            }
        }
        else
        {
            Debug.Log("in sprint else");
            if (_speed > _walkSpeed)
            {
                _speed = _speed - _walkSprintTransition * Time.deltaTime;
            }
        }
    }

    private void Jump()
    {
        if (_isGrounded)
        {
            Vector3 jumpDirection = Vector3.up;
            _rigidbody.AddForce(jumpDirection * _jumpForce * Time.deltaTime);
        }
    }

    private void CheckIsGrounded()
    {
        _isGrounded = Physics.CheckSphere(_groundDetector.position, _detectorRadius, _groundLayer);
    }

    private void OnDestroy()
    {
        _input.OnMoveInput -= Move;
        _input.OnSprintInput -= Sprint;
        _input.OnJumpInput -= Jump;
    }
}
