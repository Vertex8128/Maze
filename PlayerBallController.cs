using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerBallController : PlayerController
{
    #region Fields

    private Rigidbody _rigidbody;

    #endregion
    
    
    #region UnityMethods
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    private void Update()
    {
        Move();
        Rotate();
    }

    private void FixedUpdate()
    {
        Jump(_rigidbody);
    }
    #endregion
}
