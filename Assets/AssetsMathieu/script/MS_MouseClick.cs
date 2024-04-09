using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MS_MouseClick : MonoBehaviour
{
    [SerializeField]
    private int score;
    public static MS_MouseClick instance;
    [SerializeField]
    private TextMeshProUGUI text;

    public int Score
    {
        get { return score; }
        set { score = value; }
    }
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        score = 0;
    }
    private void FixedUpdate()
    {

        text.text = score.ToString();

        if(score >= 50)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if(score >= 20)
        {
            CB_CubeManager.instance.NumberOfCube = 2;
        }

        gameObject.transform.position = Input.mousePosition;
        Cursor.lockState = CursorLockMode.Confined; 
    }
}
