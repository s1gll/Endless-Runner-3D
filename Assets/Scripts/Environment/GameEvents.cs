using System;

public class GameEvents 
{
    public static event Action<bool> OnGamePauseStateChanged;
    public static event Action OnPlayerDeath;
    public static event Action OnCountdownFinished;

    public static void TriggerGamePauseStateChanged(bool isPaused)
    {
        OnGamePauseStateChanged?.Invoke(isPaused);
    }

    public static void TriggerPlayerDeath()
    {
        OnPlayerDeath?.Invoke();
    }
    public static void CountdownFinished()
    {
        OnCountdownFinished?.Invoke();
    }
}
