using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/Data")]
public class Data : ScriptableObject
{
    [SerializeField] private string _playerDataName;
    [SerializeField] private string _bonusHealthName;
    [SerializeField] private string _bonusSpeedName;
    [SerializeField] private string _bonusScoreName;
    private PlayerData _player;
    private BonusData _bonusHealth;
    private BonusData _bonusSpeed;
    private BonusData _bonusScore;

    public PlayerData Player
    {
        get
        {
            if (_player == null)
            {
               _player = Load<PlayerData>("Data/" + _playerDataName);
            }
            return _player;
        }
    }
    
    public BonusData BonusHealth
    {
        
        get
        {
            if (_bonusHealth == null)
            {
               _bonusHealth = Load<BonusData>("Data/" + _bonusHealthName);
            }
            return _bonusHealth;
        }
    }

    public BonusData BonusSpeed
    {
        get
        {
            if (_bonusSpeed == null)
            {
              _bonusSpeed = Load<BonusData>("Data/" + _bonusSpeedName);
            }
            return _bonusSpeed;
        }
    }
    
    public BonusData BonusScore
    {
        get
        {
            if (_bonusScore == null)
            {
              _bonusScore = Load<BonusData>("Data/" + _bonusScoreName);
            }
            return _bonusScore;
        }
    }

    private T Load<T>(string resoursePath) where T : Object
    {
       return Resources.Load<T>(Path.ChangeExtension(resoursePath, null));
    }
}
