using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScTimerN : MonoBehaviour{
    public Image timerBar; 
    public GameObject end;

    public TextMeshProUGUI timeText;
    public float maxTime = 3000f;
    float _timeRemain;

    public static ScTimerN Instance;

    private void Awake() {
        if (Instance == null) { Instance = this;}
        else { Destroy(this); }
    }

    public void Start() { _timeRemain = maxTime; end.SetActive(false); }

    private void Update() {
        if(_timeRemain > maxTime + 3000F)
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if(_timeRemain > 0) {
            _timeRemain -=1;
            int seconds = Mathf.FloorToInt(_timeRemain / 60);
            int miniSeconds = Mathf.FloorToInt(_timeRemain % 60);
            timeText.text = seconds + "." + miniSeconds;
            timerBar.fillAmount = _timeRemain / maxTime;
        } else{
            end.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void AddTime(float time){
        _timeRemain += time;
    }

    public void RemoveTime(float time) { 
        _timeRemain -= time;
    }

}
