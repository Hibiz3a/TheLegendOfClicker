using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteButton : MonoBehaviour
{
    [SerializeField] private List<Sprite> spriteRed = new List<Sprite>();
    [SerializeField] private List<Sprite> spriteYellow = new List<Sprite>();
    [SerializeField] private List<Sprite> spritePurple = new List<Sprite>();
    [SerializeField] private GameObject _button;

    [SerializeField] private float _timerSprite;

    private int _spriteNumber;
    [HideInInspector] public bool _stopCoroutine;

    [HideInInspector] public int _nbSprite = 0;

    public static SpriteButton Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SetSprite();
    }

    private void Update()
    {
        if (_stopCoroutine)
        {
            StopAllCoroutines();
            SetSprite();
            _stopCoroutine = false;
            _nbSprite = 0;
        }
    }

    public void SetSprite()
    {
        switch (Random.Range(0,3))
        {
            case 0:
                _button.gameObject.GetComponent<Image>().sprite = spriteRed[0];
                _spriteNumber = 0;
                StartCoroutine(UpdateSprite());
                break;
            case 1:
                _button.gameObject.GetComponent<Image>().sprite = spriteYellow[0];
                _spriteNumber = 1;
                StartCoroutine(UpdateSprite());
                break;
            case 2:
                _button.gameObject.GetComponent<Image>().sprite = spritePurple[0];
                _spriteNumber = 2;
                StartCoroutine(UpdateSprite());
                break;
        }
    }

    IEnumerator UpdateSprite()
    {
        yield return new WaitForSeconds(_timerSprite);
        if (_nbSprite > 1)
        {
            Life.Instance.SetImageUI();
            _nbSprite = 0;
            _button.gameObject.transform.position = new Vector2(Random.Range(64, 1856), Random.Range(64, 1026));
            SetSprite();
        }
        else
        {
            switch (_spriteNumber)
            {
                case 0:
                    _button.gameObject.GetComponent<Image>().sprite = spriteRed[_nbSprite + 1];
                    _nbSprite++;
                    break;
                case 1:
                    _button.gameObject.GetComponent<Image>().sprite = spriteYellow[_nbSprite + 1];
                    _nbSprite++;
                    break;
                case 2:
                    _button.gameObject.GetComponent<Image>().sprite = spritePurple[_nbSprite + 1];
                    _nbSprite++;
                    break;
            }
            StartCoroutine(UpdateSprite());
        }
    }
}
