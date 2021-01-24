using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour, IUpdatable
{
    [SerializeField] private float _colorDuration;
    private Renderer _renderer;
    private Color _originalColor;
    private float _currentColorDuration;
    private bool _isGoodToResetColor;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Start()
    {
        _currentColorDuration = _colorDuration;
        _originalColor = _renderer.material.color;
        BallController.OnGettingBonus += ChangeColor;
    }

    public void UpdateObject(float deltaTime)
    {
        if (_isGoodToResetColor)
        {
            _currentColorDuration -= deltaTime;
            if (_currentColorDuration <= 0)
            {
                _renderer.material.color = _originalColor;
                _currentColorDuration = _colorDuration;
                _isGoodToResetColor = false;
            }
        }
    }

    private void ChangeColor(Color color)
    {
        _renderer.material.color = color;
        _isGoodToResetColor = true;
    }
}
