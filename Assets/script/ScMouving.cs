using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScMouving : MonoBehaviour
{
    public void Teleport()
    {
        transform.position = new Vector2(Random.Range(128, 1792), Random.Range(128, 752));
        ScScore.Instance.score += 1;
        ScTimer.Instance.time += 6;
    }
}
