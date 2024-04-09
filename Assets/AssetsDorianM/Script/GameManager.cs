using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float Timer;
    public float Score;
    [SerializeField] private GameObject Button;
    [SerializeField] private TMP_Text TimerText;
    [SerializeField] private TMP_Text ScoreText;
    

    void Update()
    {
        int RoundedTimer = Mathf.RoundToInt(Timer);
        Timer -= Time.deltaTime;
        TimerText.text = ("time left = " + RoundedTimer.ToString() + "sec");
        ScoreText.text = ("Score = " + Score);
        if (Timer < 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            Destroy(Button);
        }
        if (Score >= 25)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Destroy(Button);
        }
    }
}
