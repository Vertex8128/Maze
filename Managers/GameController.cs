using System.Linq;
using UnityEngine;

public sealed class GameController : MonoBehaviour
{
   
    private IUpdatable[] _updatableObjects;

    private void Awake()
    {
        _updatableObjects = FindObjectsOfType<MonoBehaviour>().OfType<IUpdatable>().ToArray();
    }

    private void Update()
    {
        var time = Time.deltaTime;
        for (int i = 0; i < _updatableObjects.Length; i++)
        {
            _updatableObjects[i].UpdateObject(time);
        }
    }
}
