using UnityEngine;

public class FinalScoreCanvasScript : MonoBehaviour
{
    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        if (_canvasGroup.alpha > 0)
        {
            _canvasGroup.alpha -= 0.25f * Time.deltaTime;
        }
    }
}
