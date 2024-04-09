using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TpCube : MonoBehaviour
{

    [SerializeField] private float Timer;
    private float TimerLose;
    [SerializeField] private float Addtime;
    private int intTimer;
    private int intTimerlose;

    [SerializeField] private TMP_Text TimerText;

    [SerializeField] private TMP_Text TimerLoseText;

    // Update is called once per frame
    void Update()
    {
    intTimer = Mathf.RoundToInt(Timer);
    intTimerlose = Mathf.RoundToInt(TimerLose);
        TimerText.text = (intTimer + "s restant");
        TimerLoseText.text = (intTimerlose + "s survived");
        Timer -= Time.deltaTime;
        TimerLose += Time.deltaTime;


        if(Timer <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        if(intTimerlose >= 10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }


    public void SpawnRandom()
    {
        transform.localPosition = new Vector3(Random.Range(-283, 283), Random.Range(-131,131), (transform.localPosition.z));
        Timer += Addtime;
    }
}
