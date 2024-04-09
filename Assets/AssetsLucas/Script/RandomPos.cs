using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RandomPos : MonoBehaviour
{
    [SerializeField] private GameObject _button;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private AudioSource audioSource;
    private int _score = 0;
    [SerializeField] private TextMeshProUGUI _textScore;
    private Color _colorButton;
    private Color _initColor;
    [SerializeField] private float _speedColor;
    [SerializeField] private float _speedSize;
    private float _timer = 30;
    [SerializeField] private TextMeshProUGUI _timerText;
    public GameObject _uiGameOver;
    [SerializeField] private GameObject _uiVictory;
    [SerializeField] private int _scoreMax;

    public static RandomPos instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        _button.transform.position = new Vector2(Random.Range(64, 1856), Random.Range(64, 1026));
        _textScore.text = _score.ToString() + " / " + _scoreMax.ToString();
        _colorButton = _button.GetComponent<Image>().color;
        _initColor = _colorButton;
    }

    private void Update()
    {
        if (_timer > 0 )
        {
            _timer -= Time.deltaTime;
            _timerText.text = ((int)_timer).ToString();
        }
        else
        {
            _uiGameOver.SetActive(true);
        }
    }
    public void RandomPosButton()
    {
        _score++;
        if (_score >= _scoreMax)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //_uiVictory.SetActive(true);
            Time.timeScale = 0.0f;
        }
        _textScore.text = _score.ToString() + " / " + _scoreMax.ToString();
        _particleSystem.transform.position = Camera.main.ScreenToWorldPoint(_button.gameObject.transform.position);
        _particleSystem.Play();
        audioSource.Play();
        SpriteButton.Instance._stopCoroutine = true;
        StartCoroutine(SizeButton());
    }

    IEnumerator SizeButton()
    {
        if (_button.transform.localScale.x > 0)
        {
            _button.transform.localScale -= Vector3.one * _speedSize;
            _button.GetComponent<Image>().color += new Color(0, Time.deltaTime * -_speedColor, Time.deltaTime * -_speedColor, 0);
            yield return new WaitForSeconds(0.001f);
            StartCoroutine(SizeButton());
        }
        else
        {
            _button.transform.localScale = Vector3.one;
            _button.transform.position = new Vector2(Random.Range(64, 1920 - 64), Random.Range(64, 1026));
            _button.GetComponent<Image>().color = _initColor;
        }
        yield return null;
    }

    public void Restart()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("SceneLucasDarpeix");
    }

    public void NextLevel()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
