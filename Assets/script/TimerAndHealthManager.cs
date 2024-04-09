using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerAndHealthManager : MonoBehaviour
{
    private float time;
    [SerializeField] private float startTimer;
    [SerializeField] int health;
    [SerializeField] int StartHealth;
    private int score;

    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Start()
    {
        time = startTimer;
        health = StartHealth;
        score = 0;
        healthText.text = "Health : " + health;
        scoreText.text = "Score : " + score + " / 10";
    }

    public void AddTime(float timeToAdd)
    {
        time += timeToAdd;
    }

    public void AddScore()
    {
        score++;
        scoreText.text = "Score : " + score + " / 10";
        if (score == 10)
        {
            SceneManager.LoadScene(2);
        }
    }

    void Update()
    {
        time -= Time.deltaTime;
        timerText.text = "Time : " + Mathf.Round(time);
        if (time < 0)
        {
            GameOver();
        }
    }

    public void loseHealthPoint()
    {
        health--;
        healthText.text = "Health : " + health;
        if (health == 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        PlayerPrefs.SetInt("score", score);
        SceneManager.LoadScene(1);
    }
}
