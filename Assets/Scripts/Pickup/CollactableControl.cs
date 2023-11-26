using UnityEngine;
using TMPro;

public class CollactableControl : MonoBehaviour
{
    private static int _coinCount;
    [SerializeField] private TextMeshProUGUI _coinCountDisplay;
    [SerializeField] private TextMeshProUGUI _coinCountDeathScreenDisplay;
    private void OnEnable()
    {
        GameEvents.OnPlayerDeath += OnPlayerDeath;
    }

    private void OnDisable()
    {
        GameEvents.OnPlayerDeath -= OnPlayerDeath;
    }
    private void Update()
    {
        _coinCountDisplay.text = "" + _coinCount;
    }
    public static void AddCoin()
    {
        _coinCount++;
    }
    private void OnPlayerDeath()
    {
        _coinCountDeathScreenDisplay.text = _coinCountDisplay.text;
    }
}
