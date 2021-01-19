using UnityEngine;

public sealed class SpeedBonus : InteractiveObject, IUpdatable
{
    [SerializeField] private float _bonusSpeed;
    [SerializeField] private float _floatingSpeed;
    [SerializeField] private float _floatingOffset;
    private Vector3 _floatingStartPos;
    private Vector3 _floatingEndPos;

    private void Start()
    {
        _floatingStartPos = transform.position;
        _floatingEndPos = _floatingStartPos + (Vector3.up * _floatingOffset);
    }
    
    private void Float()
    {
        var floatingTime = Mathf.PingPong(Time.time, _floatingSpeed) / _floatingSpeed;;
        transform.position = Vector3.Lerp(_floatingStartPos, _floatingEndPos, floatingTime);
    }


    public void UpdateObject(float deltaTime)
    {
        Float();
    }

    public override void Interact(GameObject player)
    {
        if (player.TryGetComponent(out PlayerController playerController))
        {
            playerController.MovementSpeed += _bonusSpeed;
            gameObject.SetActive(false);
        }
    }
}
