using UnityEngine;

public class PlayerInitialization : MonoBehaviour, IInitialization
{
    private PlayerData _playerData;
    private GameObject _player;

    public PlayerInitialization (PlayerData playerData)
    {
        _playerData = playerData;
        _player = Instantiate(_playerData.Player, _playerData.Player.transform.position,
            _playerData.Player.transform.rotation);
    }

    public void Initialization()
    {
    }

    public GameObject GetPlayer()
    {
        return _player;
    }
}
