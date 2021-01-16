using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Fields

    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _groundDetectorLowPoint;
    private Vector3 _groundPosOffset;
    
    #endregion

    
    #region UnityMethods

    private void Start()
    {
        _groundPosOffset = new Vector3(0.0f,_groundDetectorLowPoint,0.0f);
    }

    #endregion

    
    #region Methods

    public void Move()
    {
        var xInput = Input.GetAxis("Horizontal");
        var zInput = Input.GetAxis("Vertical");
        var moveDirection = new Vector3(xInput,0,zInput);
        transform.Translate(moveDirection * _movementSpeed * Time.deltaTime);
    }
    
    public void Rotate()
    {
        if (Input.GetAxis("Mouse X") != 0)
        {
            var rotInput = Input.GetAxis("Mouse X");
            var rotShift = rotInput * _rotationSpeed * Time.deltaTime;
            transform.rotation *= Quaternion.Euler(0.0f, rotShift, 0.0f);
        }
    }

    public void Jump(Rigidbody rigidbody)
    {
        if (Input.GetButtonDown("Jump") && DetectGrounded())
        {
            rigidbody.AddForce(Vector3.up * Mathf.Sqrt(_jumpHeight * -2 * Physics.gravity.y), ForceMode.VelocityChange);    
        }
    }
    
    public bool DetectGrounded()
    {
        var isGrounded = Physics.Linecast(transform.position + Vector3.up, transform.position - _groundPosOffset);
        return isGrounded;
    }

    #endregion
}
