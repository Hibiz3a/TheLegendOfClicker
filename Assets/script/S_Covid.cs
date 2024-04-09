using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_Covid : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI m_scoretext;

    [SerializeField]
    private TextMeshProUGUI m_highScoreText;

    [SerializeField]
    private TextMeshProUGUI m_livestext;

    [SerializeField]
    private GameObject m_retryButton;

    private float m_maxcooldown = 3f;
    private float m_cooldown = 3f;
    private int m_lives = 3;
    private float m_timer = 0f;
    private float m_highScore = 0f;

    public void GetTeleported()
    {
        if (m_lives > 0)
        {
            m_maxcooldown *= 0.90f;
            m_cooldown = m_maxcooldown;
            transform.position = new Vector3(Random.Range(128, 1920 - 129), Random.Range(128, 1080 - 129), 0);
        }
    }

    private void Update()
    {
        if (m_lives > 0)
        {
            m_cooldown -= Time.deltaTime;
            m_timer += Time.deltaTime;
            if (m_cooldown <= 0)
            {
                m_lives--;
                m_livestext.text = "Lives : " + m_lives.ToString();
                m_maxcooldown *= 0.90f;
                m_cooldown = m_maxcooldown;
                transform.position = new Vector3(Random.Range(128, 1920 - 129), Random.Range(128, 1080 - 129), 0);
            }
            m_scoretext.text = "Score : " + m_timer.ToString();
            float value = m_cooldown / m_maxcooldown;
            transform.localScale = new Vector3(value, value, value);
            if (m_timer >= 7f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
            m_retryButton.SetActive(true);
        }
    }

    public void Retry()
    {
        if (m_highScore < m_timer)
        {
            m_highScore = m_timer;
            m_highScoreText.text = "HighScore : " + m_highScore.ToString();
        }

        m_maxcooldown = 3f;
        m_cooldown = 3f;
        m_lives = 3;
        m_timer = 0f;
        m_livestext.text = "Lives : " + m_lives.ToString();
        m_scoretext.text = "Time : " + m_timer.ToString();
        m_retryButton.SetActive(false);
    }

}
