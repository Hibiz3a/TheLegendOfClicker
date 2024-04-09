using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScScore : MonoBehaviour
{
    public int score;

    [SerializeField]private TextMeshProUGUI scoreAmount;
    [SerializeField]private TextMeshProUGUI finalScoreAmount;

    public static ScScore Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        score = 0;
        scoreAmount.text = score.ToString();
    }

    private void Update()
    {
        scoreAmount.text = score.ToString();
        finalScoreAmount.text = "Final Score : " + scoreAmount.text;
    }
}
