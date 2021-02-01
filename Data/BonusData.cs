using UnityEngine;

[CreateAssetMenu (fileName = "Bonus", menuName = "Data/Bonuses")]
public class BonusData : ScriptableObject
{
    public GameObject Bonus;
    public enum BonusType { Health, Speed, Score }
    [SerializeField] private BonusType _type;
    [SerializeField] private int _bonusNumbers;
    [SerializeField] private float _poins;
    [SerializeField] private float _rotationSpeed;

    public BonusType Type => _type;
    public float Poins => _poins;
    public int BonusNumbers => _bonusNumbers;
    public float RotationSpeed => _rotationSpeed;
}
