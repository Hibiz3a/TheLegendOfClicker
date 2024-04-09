using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.UI.Button;
using UnityEngine.Serialization;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class ButtonCustom : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public bool _interactable = true;
    public bool _interactableImage = false;

    [SerializeField] private TextMeshProUGUI _textScore;

    [SerializeField] private TextMeshProUGUI _textTimer;

    private int _point = 0;

    private float _time = 30f;


    [Header("Colors")]
    [SerializeField] private Color _enterColor;
    [SerializeField] private Color _enterColorImage;
    [SerializeField] private Color _exitColor;
    [SerializeField] private Color _exitColorImage;
    [SerializeField] private Color _clickColor;
    [SerializeField] private Color _clickColorImage;

    [Space(15)]
    [FormerlySerializedAs("onClick")]
    [SerializeField] private ButtonClickedEvent _onClick = new ButtonClickedEvent();

    [Space(15)]
    [FormerlySerializedAs("onEnter")]
    [SerializeField] private ButtonClickedEvent _onEnter = new ButtonClickedEvent();

    [Space(15)]
    [FormerlySerializedAs("onExit")]
    [SerializeField] private ButtonClickedEvent _onExit = new ButtonClickedEvent();

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_interactable)
        {
            _onEnter.Invoke();
            if (GetComponentInChildren<TMP_Text>() != null)
                GetComponentInChildren<TMP_Text>().color = _enterColor;
        }
        if (_interactableImage)
        {
            _onEnter.Invoke();
            if (GetComponentInChildren<Image>() != null)
                GetComponentInChildren<Image>().color = _enterColorImage;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (_interactable)
        {
            _onExit.Invoke();
            if (GetComponentInChildren<TMP_Text>() != null)
                GetComponentInChildren<TMP_Text>().color = _exitColor;
        }
        if (_interactableImage)
        {
            _onExit.Invoke();
            if (GetComponentInChildren<Image>() != null)
                GetComponentInChildren<Image>().color = _exitColorImage;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_interactable)
        {
            _onClick.Invoke();
            if (GetComponentInChildren<TMP_Text>() != null)
                GetComponentInChildren<TMP_Text>().color = _clickColor;
        }
        if (_interactableImage)
        {
            if (GetComponentInChildren<Image>() != null)
                GetComponentInChildren<Image>().color = _clickColorImage;
            MovementObject();

            AddPoint();
        }
    }

    public void MovementObject()
    {
        int _randX = Random.Range((0 +128/2), (1920 - 128 / 2));
        int _randY = Random.Range((0 + 128 / 2), (1080 - 128 / 2));
        transform.position = new Vector3(_randX, _randY, 0);
    }

    void Update()
    {
        _time -= Time.deltaTime;
        _textScore.text = "Score :" + _point;
        _textTimer.text = "Timer :" + (int)_time;

        if (_time <= 0)
        {
            if ( _point >= 30)
            {
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);
            }
        }

    }

    public void AddPoint()
    {
        _point++;
    }
}
