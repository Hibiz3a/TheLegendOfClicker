using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class ScTimer : MonoBehaviour
{
    public float time;

    [SerializeField] private TextMeshProUGUI timeLeft;

    public static ScTimer Instance;

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
        time = 11;
        timeLeft.text = time.ToString();
    }

    private void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            timeLeft.text = ((int)time).ToString();
        }

        if (time > 11)
        {
            time = 11;
        }
    }
}
