using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private float _hp;
    public float Hp
    {
        get => _hp;
        set => _hp = value;
    }
}
