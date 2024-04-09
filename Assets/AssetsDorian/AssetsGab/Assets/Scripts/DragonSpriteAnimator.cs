using UnityEngine;
using UnityEngine.UI;

public class DragonSpriteAnimator : MonoBehaviour
{
    private Image _image;

    [SerializeField] private Sprite[] _redSprites;
    [SerializeField] private Sprite[] _blueSprites;
    private int _index = 0;

    [SerializeField] private float _delayToNextFrame;
    private float _timer = 0;

    private bool _isRed = false;

    [SerializeField] private bool _destroyAtEnd = false;

    private void Awake()
    {
        _image = GetComponent<Image>();
        if (Random.Range(0f, 100f) < 50)
        {
            _isRed = true;
        }
    }

    private void Start()
    {
        UpdateSprite();
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        UpdateSprite();
        if (_timer > _delayToNextFrame)
        {
            _index += 1;
            _timer = 0;
        }
    }

    private void UpdateSprite()
    {
        if (_isRed)
        {
            if (_index >= _redSprites.Length)
            {
                _index = 0;
                if (_destroyAtEnd) Destroy(gameObject);
            }
            _image.sprite = _redSprites[_index];
        }
        else
        {
            if (_index >= _blueSprites.Length)
            {
                _index = 0;
                if (_destroyAtEnd) Destroy(gameObject);
            }
            _image.sprite = _blueSprites[_index];
        }
    }
}
