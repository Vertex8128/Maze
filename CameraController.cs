using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class CameraController : MonoBehaviour
{
    #region Fields

    [SerializeField] private PlayerController _playerController;
    private Vector3 _offset;
    
    #endregion
    

    #region UnityMethods

    private void Start ()
    {
        _offset = transform.position - _playerController.transform.position;
    }

    private void LateUpdate ()
    {
        transform.position = _playerController.transform.position + _offset;
    }

    #endregion
}
