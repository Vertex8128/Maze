using UnityEngine;
using Random = UnityEngine.Random;

public class CameraController : MonoBehaviour, IUpdatable
{

    [SerializeField] private float _shakeDuration;
    [SerializeField] private float _shakeAmount;
    [SerializeField] private float _decreaseFactor;
	private Vector3 _originalPos;
    private bool _isGoodToShake;
    private float _currentShakeDuration;

    private void Start()
    {
        _originalPos = transform.localPosition;
        _currentShakeDuration = _shakeDuration;
        BallController.OnGettingBonus += SetShaken;
    }

    public void UpdateObject(float deltaTime)
    {
        if (_isGoodToShake)
        {
            Shake();
        }
    }

    private void SetShaken(Color color)
    {
        _isGoodToShake = true;
    }

    private void Shake()
    {
        if (_currentShakeDuration >= 0)
        {
            transform.localPosition = _originalPos + Random.insideUnitSphere * _shakeAmount;
            _currentShakeDuration -= Time.deltaTime * _decreaseFactor;
        }
        else
        {
            transform.localPosition = _originalPos;
            _currentShakeDuration = _shakeDuration;
            _isGoodToShake = false;
        }
    }
}
