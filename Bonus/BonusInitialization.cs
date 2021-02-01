using UnityEngine;

public class BonusInitialization : MonoBehaviour, IInitialization
{
    private readonly int _levelLength = 17;
    private readonly BonusData _bonusData;
    private GameObject _bonus;

    public BonusInitialization(BonusData bonusData)
    {
        _bonusData = bonusData;
        _bonus = Instantiate(_bonusData.Bonus, FindAvailiableSpot(), _bonusData.Bonus.transform.rotation);
    }
    public void Initialization()
    {
    }

    private Vector3 FindAvailiableSpot()
    {
        var spawnPoint = Vector3.zero;
        
        Collider[] hitColliders;
        
        do
        {
            var xPos = Random.Range(-_levelLength, _levelLength);
            var zPos = Random.Range(-_levelLength, _levelLength);
            spawnPoint.Set(xPos, 0.5f, zPos);
            hitColliders = Physics.OverlapSphere(spawnPoint, 0.5f);
        } while (hitColliders.Length != 0);

        return spawnPoint;
    }
    
    public GameObject GetBonus()
    {
        return _bonus;
    }
}
