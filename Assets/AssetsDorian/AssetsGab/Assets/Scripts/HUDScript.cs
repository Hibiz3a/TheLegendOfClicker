using TMPro;
using UnityEngine;

public class HUDScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _timerText;

    private void Update()
    {
        _scoreText.text = "Coins: " + GameManagerDragonCave.Instance.Score.ToString() + "/" + GameManagerDragonCave.Instance.ScoreToBeat.ToString();
        _timerText.text = "Timer: " + ((int)GameManagerDragonCave.Instance.Timer).ToString();
    }
}
