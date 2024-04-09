using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text bestScoreText;
    public static int scoreCount;
    public static int bestScoreCount;


    private void Start()
    {
        if (PlayerPrefs.HasKey("BestScore"))
        {
            bestScoreCount = PlayerPrefs.GetInt("BestScore");
        }
    }

    private void Update()
    {
        if (scoreCount > bestScoreCount)
        {
            bestScoreCount = scoreCount;
            PlayerPrefs.SetInt("BestScore", bestScoreCount);
        }

        scoreText.text = "Score : " + Mathf.Round(scoreCount);
        bestScoreText.text = "BestScore : " + bestScoreCount;

        ScoreWin();
    }

    public void ScoreWin()
    {
        if (scoreCount >= 10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
