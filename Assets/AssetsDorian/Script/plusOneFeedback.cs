using UnityEngine;

public class plusOneFeedback : MonoBehaviour
{
    Rigidbody2D _rb;
    Transform _transform;
    [SerializeField] RectTransform _playerTransform;

    public static plusOneFeedback Instance;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _transform = transform;
        if (Instance == null)
            Instance = this;
    }

    public void Launch()
    {
        _transform.position = new Vector3(Random.Range(-Screen.width/200, Screen.width/200), Random.Range(-Screen.height / 200, Screen.height / 200));
        _rb.velocity = Vector3.zero;
        print(_playerTransform.localPosition);
        _rb.AddForce(new Vector3(Random.Range(-100, 100), 100));
    }
}
