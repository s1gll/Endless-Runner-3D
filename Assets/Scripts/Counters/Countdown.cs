using System.Collections;
using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _countdownText;
    [SerializeField] private  string _goText = "GO!";


    private void Start()
    {
        StartCoroutine(StartCountdown());
    }

    private IEnumerator StartCountdown()
    {
        int countdownValue = 3;

        while (countdownValue > 0)
        {
            _countdownText.text = countdownValue.ToString();
            yield return new WaitForSeconds(1f);
            countdownValue--;
        }

        _countdownText.text = _goText;
        yield return new WaitForSeconds(1f);

        _countdownText.gameObject.SetActive(false);
        GameEvents.CountdownFinished();

      
    }
}