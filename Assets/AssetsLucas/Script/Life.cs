using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    [SerializeField] private List<Image> _imageHeart = new();
    public static Life Instance;
    public int _nbLife;
    [SerializeField] private Sprite _spriteHeartNone;
    private void Awake()
    {
        Instance = this;
    }

    public void SetImageUI()
    {
        _nbLife--;
        if (_nbLife <= 0 )
        {
            RandomPos.instance._uiGameOver.SetActive(true);
            Time.timeScale = 0.0f;
        }
        for (int i = 0; i < _imageHeart.Count - _nbLife; i++)
        {
            _imageHeart[_imageHeart.Count - i - 1].sprite = _spriteHeartNone;
        }
    }
}
