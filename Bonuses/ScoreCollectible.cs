public sealed class ScoreCollectible : CollectibleObject
{
    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    public override void Collect()
    {
        _gameManager.UpdateScore();
        Destroy(gameObject);
    }
}
