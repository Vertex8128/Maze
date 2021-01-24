using System;
using UnityEngine;

public sealed class BallController : PlayerController, IUpdatable
{
    #region Fields

    private Rigidbody _rigidbody;
    public static event Action <Color> OnGettingBonus;

    #endregion
    
    
    #region UnityMethods
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    public void UpdateObject (float deltaTime)
    {
        GetMovementInput();
        Move(deltaTime);
        Rotate(deltaTime);
        Jump(_rigidbody);
    }
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out InteractiveObject interactiveObject))
        {
            interactiveObject.Interact(gameObject);
        }
        
        if (other.TryGetComponent(out CollectibleObject collectibleObject))
        {
            collectibleObject.Collect();
        }

        var objColor = other.GetComponent<Renderer>().material.color;
        OnGettingBonus?.Invoke(objColor);
    }

    #endregion
}
