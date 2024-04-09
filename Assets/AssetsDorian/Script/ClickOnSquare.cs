using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickOnSquare : MonoBehaviour
{
    RectTransform _transform;
    Coroutine _coroutine;
    int _count = 0;
    int _health = 3;

    bool _lose = false;

    public static ClickOnSquare Instance;

    [SerializeField] TextMeshProUGUI _healthText;
    [SerializeField] TextMeshProUGUI _scoreText;
    [SerializeField] GameObject _loseText;
    [SerializeField] GameObject _hurtImage;

    Image _image;

    public UnityEvent Win;

    private void Awake()
    {
        _transform = GetComponent<RectTransform>();
        _image = GetComponent<Image>();
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        _transform.localPosition = new Vector3(Random.Range(-Screen.width / 2, Screen.height / 2), Random.Range(-Screen.height / 2, Screen.height / 2));
        print(_transform.position);
        _loseText.gameObject.SetActive(false);
        _image.sprite = SpritesManager.Instance.ChoseOneSprite();
        _hurtImage.SetActive(false);
    }

    public void Click()
    {
        if(!_lose)
        {
            _image.sprite = SpritesManager.Instance.ChoseOneBrokenSprite();
            Feedbacks.Instance.StartShrink(gameObject);
            _count++;
            if(_count >= 10)
            {
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
                Win?.Invoke();
            }
            plusOneFeedback.Instance.Launch();
            if (_coroutine != null)
                StopCoroutine(_coroutine);
            _coroutine = StartCoroutine(TeleportToNewPos());
        }
    }

    IEnumerator TeleportToNewPos()
    {
        if(!_lose)
        {
            yield return new WaitForSeconds(1);
            StartCoroutine(Hurt());
            _health--;

            if (_health <= 0)
            {
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);
                print("you lose");
                _lose = true;
                _loseText.gameObject.SetActive(true);
            }
            _transform.localPosition = new Vector3(Random.Range(-Screen.width / 2, Screen.height / 2), Random.Range(-Screen.height / 2, Screen.height / 2));
            print("failed");
            if (_coroutine != null)
                StopCoroutine(_coroutine);
            _coroutine = StartCoroutine(TeleportToNewPos());
        }
    }

    private void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        _healthText.text = _health.ToString();
        _scoreText.text = _count.ToString();
    }

    IEnumerator Hurt()
    {
        _hurtImage.SetActive(true);
        yield return new WaitForSeconds(.1f);
        _hurtImage.SetActive(false);
    }
}
