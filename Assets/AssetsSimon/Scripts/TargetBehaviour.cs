using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehaviour : MonoBehaviour
{
    [SerializeField] private float timeLimit;
    private float timer;

    private void Start()
    {
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeLimit)
        {
            Destroy(gameObject);
        }
    }
}
