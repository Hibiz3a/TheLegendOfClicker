using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boutonTP : MonoBehaviour
{
    [SerializeField] private float addToTimer;
    [SerializeField] private float Timer;
    private float timeSurvived;
    private int intTimer;
    private int surviveIntTimer;
    [SerializeField] TMP_Text timerText;
    [SerializeField] TMP_Text survivedTime;
    [SerializeField] GameObject covidPrefab;

    private void Update()
    {
        intTimer = Mathf.RoundToInt(Timer);
        surviveIntTimer = Mathf.RoundToInt(timeSurvived);
        timerText.text = (intTimer + "s réstants");
        survivedTime.text = (surviveIntTimer + "s survécus");
        Timer -= Time.deltaTime;
        timeSurvived += Time.deltaTime;

        if (Timer !< 0)
        {
            Destroy(gameObject);
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);
        }

        if(timeSurvived >= 10)
        {
            Destroy(gameObject);
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void tpbuton()
    {
        transform.localPosition = new Vector3(Random.Range(-897, 897), Random.Range(-477, 477), transform.localPosition.z);
        Timer += addToTimer;
        FindObjectOfType<AudioManager>().PlaySound("buttonPressed");
    }

    public void GameOver()
    {
        if (Timer >= 2)
        {
            
        }
    }
}
