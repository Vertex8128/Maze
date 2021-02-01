public class GameInitialization 
{
    public GameInitialization (Controllers controllers, Data data)
    {
        var inputInitialization = new InputInitialization();
        controllers.Add(inputInitialization);
        
        var inputController = new InputController(inputInitialization.GetInput());
        controllers.Add(inputController);
        
        var playerInitialization = new PlayerInitialization(data.Player);
        controllers.Add(playerInitialization);
        
        var playerMoveController = new PlayerMoveController(playerInitialization.GetPlayer(), data.Player, inputInitialization.GetInput());
        controllers.Add(playerMoveController);
        
        var gameWinController = new GameWinController();
        var playerCollisionDetector = new PlayerCollisionDetector(playerInitialization.GetPlayer(), data.Player, gameWinController);
        controllers.Add(playerCollisionDetector);

        BonusInitialation(data.BonusHealth, data.BonusHealth.BonusNumbers, controllers, playerCollisionDetector);
        BonusInitialation(data.BonusSpeed, data.BonusSpeed.BonusNumbers, controllers, playerCollisionDetector);
        BonusInitialation(data.BonusScore, data.BonusScore.BonusNumbers, controllers, playerCollisionDetector);
    }
    
    private void BonusInitialation<T>(T type, int bonusNumbers, Controllers controllers, PlayerCollisionDetector collisionDetector) where T: BonusData
    {
        for (int i = 1; i <= bonusNumbers; i++)
        {
            var bonusInstalation = new BonusInitialization(type);
            controllers.Add(bonusInstalation);
            collisionDetector.Add(bonusInstalation.GetBonus().GetInstanceID(), type);
            var bonusMoveController = new BonusMoveController(bonusInstalation.GetBonus(), type);
            controllers.Add(bonusMoveController);
        }
    }
}
