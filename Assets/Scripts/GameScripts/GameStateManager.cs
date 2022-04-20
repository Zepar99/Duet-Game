
public class GameStateManager : SingletonGeneric<GameStateManager>
{
    private static GameStateManager _instance;
    public GameState currentGameState { get; private set; }
    public delegate void GameStateChangeHandler(GameState newGameState);
    public event GameStateChangeHandler OnGameStateChange;


    private GameStateManager()
    {

    }

    public void SetState(GameState newGameState)
    {
        if (currentGameState == newGameState)
            return;

        currentGameState = newGameState;
        OnGameStateChange?.Invoke(newGameState);
    }
}
