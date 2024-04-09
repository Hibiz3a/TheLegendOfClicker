using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScVictory : MonoBehaviour
{
    private void Update()
    {
        if (ScScore.Instance.score >= 15)
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
