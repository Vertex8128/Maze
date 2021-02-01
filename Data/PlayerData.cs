using UnityEngine;

[CreateAssetMenu (fileName = "Player", menuName = "Data/Player")]
public class PlayerData : ScriptableObject
{
    public GameObject Player;
    [SerializeField] private float _health;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _jumpHeight;

    public float Health
    {
        get => _health;
        set => _health = value;
    }
    public float MovementSpeed    
    {
        get => _movementSpeed;
        set => _movementSpeed = value;
    }
    
    public float RotationSpeed  => _rotationSpeed; 
    public float JumpHeight  => _jumpHeight;
}
