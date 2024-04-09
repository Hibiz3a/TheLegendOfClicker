using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScGameOver : MonoBehaviour
{
    [SerializeField]private GameObject GameOver;

    void Start()
    {
        GameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (ScTimer.Instance.time <= 0)
        {
            GameOver.SetActive(true);
        }
    }
}
