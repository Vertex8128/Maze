using UnityEngine;

public sealed class GameManager : MonoBehaviour
{
    [SerializeField] private int _scoreForWin;
    private int _currentScore;

    public void UpdateScore()
    {
        _currentScore++;
        if (_currentScore >= _scoreForWin)
        {
            Debug.Log("WIN");
        }
    }
}
