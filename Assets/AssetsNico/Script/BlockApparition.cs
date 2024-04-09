using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockApparition : MonoBehaviour
{
    [SerializeField] private Image square;


    public void OnClick()
    {
        square.transform.position = new Vector3(Random.Range(-5, 5), Random.Range(-3, 3), 0);
        ScoreManager.scoreCount++;
    }
}
