using UnityEngine;
using UnityEngine.UI;

public class Feedbacks : MonoBehaviour
{
    bool _isShrinkingAndChangingColor = false;
    GameObject _square;
    Vector3 _scale;
    Color _baseColor;
    public static Feedbacks Instance;
    RectTransform _transform;
    Image _squareImage;

    float _elapsed;
    float _time = .1f;
    Image _image;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        _transform = GetComponent<RectTransform>();
        _image = GetComponent<Image>();
    }
    public void StartShrink(GameObject square)
    {
        _square = square;
        _scale = _square.transform.localScale;
        _squareImage = _square.GetComponent<Image>();
        _baseColor = _squareImage.color;
        _isShrinkingAndChangingColor = true;
    }

    private void ShrinkAndChangeColor()
    {
        if (_isShrinkingAndChangingColor)
        {
            if (_elapsed < _time)
            {
                
                //_square.transform.localScale = Vector3.Lerp(_scale, Vector3.zero, _elapsed / _time);
                _elapsed += Time.deltaTime;
            }
            else
            {
                _square.transform.localScale = _scale;
                _isShrinkingAndChangingColor = false;
                _elapsed = 0;
                _transform.localPosition = new Vector3(Random.Range(-Screen.width / 2, Screen.height / 2), Random.Range(-Screen.height / 2, Screen.height / 2));
                _image.sprite = SpritesManager.Instance.ChoseOneSprite();
                _squareImage.color = _baseColor;
            }
        }
    }

    private void Update()
    {
        ShrinkAndChangeColor();
    }
}
