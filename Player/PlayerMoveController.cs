using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : IExecute, ICleanup
{
    private readonly Transform _playerTransform;
    private readonly Rigidbody _playerRigidbody;
    private PlayerData _playerData;
    private readonly IUserInput _userInput;

    private Vector3 _move;
    private float _horizontalInput;
    private float _verticalInput;
    private float _rotationInput;
    private bool _jumpInput;


    public PlayerMoveController(GameObject player, PlayerData playerData, IUserInput userInput)
    {
        _playerTransform = player.transform;
        _playerRigidbody = player.GetComponent<Rigidbody>();
        _playerData = playerData;
        _userInput = userInput;
        _userInput.OnHorizontalAxis += HorizontalMove;
        _userInput.OnVerticalAxis += VerticalMove;
        _userInput.OnRotationInput += Rotation;
        _userInput.OnJumpInput += Jump;
    }

    private void HorizontalMove(float value)
    {
        _horizontalInput = value;
    }

    private void VerticalMove(float value)
    {
        _verticalInput = value;
    }

    private void Rotation(float value)
    {
        _rotationInput = value;
    }

    private void Jump(bool value)
    {
        _jumpInput = value;
    }

    public void Execute(float deltaTime)
    {
        var movementSpeed = _playerData.MovementSpeed * deltaTime;
        _move.Set(_horizontalInput * movementSpeed, 0.0f, _verticalInput * movementSpeed);
       _playerTransform.position += _playerTransform.TransformDirection(_move);

        var rotation = _rotationInput * _playerData.RotationSpeed * deltaTime;
        _playerTransform.rotation *= Quaternion.Euler(0.0f, rotation, 0.0f);

        if (_jumpInput && DetectGrounded())
        {
            _playerRigidbody.AddForce(Vector3.up * Mathf.Sqrt(_playerData.JumpHeight * -2 * Physics.gravity.y), ForceMode.VelocityChange);    
        }
    }

    public bool DetectGrounded()
    {
        var isGrounded = Physics.Linecast(_playerTransform.position + Vector3.up, _playerTransform.position + Vector3.down * 0.5f);
        return isGrounded;
    }
    
    public void Cleanup()
    {
        _userInput.OnHorizontalAxis -= HorizontalMove;
        _userInput.OnVerticalAxis -= VerticalMove;
        _userInput.OnRotationInput -= Rotation;
        _userInput.OnJumpInput -= Jump;
    }
}
