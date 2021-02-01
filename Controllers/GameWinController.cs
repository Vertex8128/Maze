using UnityEngine;

public class GameWinController
{
    private int _scoreToWin = 3;
    private int _currentScore = 0;

    public void SetScore()
    {
        _currentScore++;
        if (_currentScore >= _scoreToWin)
        {
            Debug.Log("WIN");
        }
    }
}
