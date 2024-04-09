using Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableObject : MonoBehaviour, IPointerClickHandler
{
    private Vector2 _goingToPos = Vector2.zero;
    private RectTransform _transform;

    private float _maxSpeed = 500;
    private float _minSpeed = 300;

    private void Awake()
    {
        _transform = GetComponent<RectTransform>();
        GetNextPos();
    }

    private void Update()
    {
        _transform.localPosition = Vector3.MoveTowards(_transform.localPosition, _goingToPos, Random.Range(_minSpeed, _maxSpeed) * Time.deltaTime);
        if ((Vector2)_transform.localPosition == _goingToPos)
        {
            GetNextPos();
        }
    }

    private void GetNextPos()
    {
        _goingToPos = new Vector2(Random.Range(-960 + (128 / 2), 960 - (128 / 2)), Random.Range(-540 + (128 / 2), 540 - (128 / 2)));
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameManagerDragonCave.Instance.GetComponent<CinemachineImpulseSource>().GenerateImpulse();
        GameManagerDragonCave.Instance.CubeClicked(gameObject);
    }
}
