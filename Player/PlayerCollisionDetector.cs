using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDetector : IExecute
{
    private GameObject _player;
    private PlayerData _playerData;
    private GameWinController _gameWinController;
    private Dictionary<int, BonusData> _bonusDataList;

    public PlayerCollisionDetector(GameObject player, PlayerData playerData, GameWinController gameWinController)
    {
        _player = player;
        _playerData = playerData;
        _gameWinController = gameWinController;
        _bonusDataList = new Dictionary<int, BonusData>();
    }

    public void Add(int id, BonusData bonusData)
    {
        _bonusDataList.Add(id, bonusData);
    }

    public void Execute(float deltaTime)
    {
        var colliders = Physics.OverlapSphere(_player.transform.position, 0.4f);

        foreach (var collider in colliders)
        {
            ApplyEffect(collider);
        }
    }

    private void ApplyEffect(Collider collider)
    {
        BonusData bonusData;
        if (_bonusDataList.TryGetValue(collider.gameObject.GetInstanceID(), out bonusData))
        {
            switch (bonusData.Type)
            {
                case BonusData.BonusType.Health: _playerData.Health += bonusData.Poins;
                    break;
                case BonusData.BonusType.Speed: _playerData.MovementSpeed += bonusData.Poins;
                    break;
                case BonusData.BonusType.Score: _gameWinController.SetScore(); 
                    break;
            }
            
            collider.gameObject.SetActive(false);
        }
    }
}