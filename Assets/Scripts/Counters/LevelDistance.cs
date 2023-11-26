using UnityEngine;
using TMPro;

public class LevelDistance : MonoBehaviour
{
    [SerializeField] private  TextMeshProUGUI _distanceDisplay;
    [SerializeField] private  TextMeshProUGUI _deathScreenDistance;
    private int _distanceRun;
    private float _timeSinceLastDistance = 0f;
    [SerializeField] private  float _distanceDelay = 1f;
    private bool _isDistanceActive = false;
    private void OnEnable()
    {
        GameEvents.OnCountdownFinished += OnCountdownFinished;
        GameEvents.OnPlayerDeath += OnPlayerDeath;
        GameEvents.OnGamePauseStateChanged += OnGamePauseStateChanged;
    }

    private void OnDisable()
    {
        GameEvents.OnCountdownFinished -= OnCountdownFinished;
        GameEvents.OnPlayerDeath -= OnPlayerDeath;
        GameEvents.OnGamePauseStateChanged -= OnGamePauseStateChanged;
    }

    private void Update()
    {
        if (_isDistanceActive)
        {
            _timeSinceLastDistance += Time.deltaTime;

            if (_timeSinceLastDistance >= _distanceDelay)
            {
                AddDistance();
                _timeSinceLastDistance = 0f;
            }
        }
    }

    private void AddDistance()
    {
        _distanceRun++;
        _distanceDisplay.text = _distanceRun.ToString();
    }

    private void OnPlayerDeath()
    {
        _deathScreenDistance.text = _distanceDisplay.text;
        _isDistanceActive = false;
    }
    private void OnCountdownFinished()
    {
        _isDistanceActive = true;

    }

    private void OnGamePauseStateChanged(bool isPaused)
    {
        _isDistanceActive = !isPaused;
    }
}