using UnityEngine;

[RequireComponent(typeof(InputManager))]
public class PlayerController : MonoBehaviour
{
    #region Fields

    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _jumpHeight;
    private InputManager _inputManager;
    private Vector3 _moveInput;
    private float _rotationInput;
    private bool _jumpInput;
    
    #endregion


    #region Properties

    public float MovementSpeed
    {
        get => _movementSpeed;
        set => _movementSpeed = value;
    }

    #endregion
    
    
    #region UnityMethods

    private void Awake()
    {
        _inputManager = GetComponent<InputManager>();
    }

    #endregion

    
    #region Methods

    public void GetMovementInput()
    {
        _moveInput = _inputManager.GetMovemnet();
        _rotationInput = _inputManager.GetRotation();
        _jumpInput = _inputManager.GetJump();
    }
    
    public void Move(float deltaTime)
    {
        transform.Translate(_moveInput * _movementSpeed * deltaTime);
    }
    
    public void Rotate(float deltaTime)
    {
        if (_rotationInput != 0)
        {
            var rotShift = _rotationInput * _rotationSpeed * deltaTime;
            transform.rotation *= Quaternion.Euler(0.0f, rotShift, 0.0f);
        }
    }

    public void Jump(Rigidbody rigidbody)
    {

        if (_jumpInput && DetectGrounded())
        {
            rigidbody.AddForce(Vector3.up * Mathf.Sqrt(_jumpHeight * -2 * Physics.gravity.y), ForceMode.VelocityChange);    
        }
    }
    
    public bool DetectGrounded()
    {

        var isGrounded = Physics.Linecast(transform.position + Vector3.up, transform.position + Vector3.down * 0.5f);
        return isGrounded;
    }

    #endregion
}
