using UnityEngine;

public enum GameState
{
    Gameplay,
    Pause,
    GameOver
}

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerMove _pm;
    [SerializeField] private GameObject _deathScreen;
    [SerializeField] private GameObject _pauseScreen;
    [SerializeField] private GameState _currentState = GameState.Gameplay;
    private bool _isPaused = false;
    [SerializeField] private AudioSource _mainMusic;
    [SerializeField] private float _deathTimer;
    [SerializeField] private float _deathDelay = 2f;


    private void Update()
    {
        switch (_currentState)
        {
            case GameState.Gameplay:
                UpdateGameplay();
                break;
            case GameState.Pause:
                UpdatePause();
                break;
            case GameState.GameOver:
                UpdateGameOver();
                break;
        }
    }

    private void UpdateGameplay()
    {
        Time.timeScale = 1f;
        IsDead();
        CheckForPause();
    }

    private void UpdatePause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
            GameEvents.TriggerGamePauseStateChanged(_isPaused);
        }
        if (!_isPaused)
        {
            GameEvents.TriggerGamePauseStateChanged(false);
            ChangeState(GameState.Gameplay);
        }
    }

    private void UpdateGameOver()
    {
        _deathTimer += Time.deltaTime;
        if (_deathTimer >= _deathDelay)
        {
            _deathTimer = 0;

            _deathScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }



    private void IsDead()
    {
        if (_pm.IsGameOver)
        {

            _mainMusic.Stop();
            GameEvents.TriggerPlayerDeath();
            ChangeState(GameState.GameOver);
        }
    }

    private void CheckForPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
            if (_currentState == GameState.Gameplay)
            {
                ChangeState(GameState.Pause);
            }
            else if (_currentState == GameState.Pause)
            {
                ChangeState(GameState.Gameplay);
            }
        }
    }

    public void TogglePause()
    {
        _isPaused = !_isPaused;
        _pauseScreen.SetActive(_isPaused);
        Time.timeScale = _isPaused ? 0f : 1f;
    }

    public void ChangeState(GameState newState)
    {
        _currentState = newState;
    }
}

