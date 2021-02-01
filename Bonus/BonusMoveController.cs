using UnityEngine;

public class BonusMoveController : IExecute
{
    private readonly GameObject _bonus;
    private readonly BonusData _bonusData;
    public BonusMoveController(GameObject bonus, BonusData bonusData)
    {
        _bonus = bonus;
        _bonusData = bonusData;
    }

    public void Execute(float deltaTime)
    {
        _bonus.transform.Rotate(Vector3.up * (_bonusData.RotationSpeed * deltaTime));
    }
}
