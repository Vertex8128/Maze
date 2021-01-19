using UnityEngine;

public sealed class HealthBonus : InteractiveObject, IUpdatable
{
    [SerializeField] private float _bonusHp;
    [SerializeField] private float _rotationSpeed;

    private void Rotate(float deltaTime)
    {
        transform.Rotate(Vector3.up * (_rotationSpeed * deltaTime));
    }
    
    public void UpdateObject(float deltaTime)
    {
        Rotate(deltaTime);
    }

    public override void Interact(GameObject player)
    {
        if (player.TryGetComponent(out HealthController healthController))
        {
            healthController.Hp += _bonusHp;
            gameObject.SetActive(false);
        }
    }
}
