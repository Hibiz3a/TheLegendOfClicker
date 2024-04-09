using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class CubeScript : MonoBehaviour, IPointerClickHandler
{
    private bool _isShrinking = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        GameManagerD.instance.SpawnCube();
        GameManagerD.instance.AddScore();
        StartCoroutine(DeathAnim());

        if (!GameManagerD.instance._isGameOn)
            GameManagerD.instance._isGameOn = true;
    }

    // condition de defaite si le joueur ne touche pas l'ecran le cube rétrécir et si le cube arrive a zero il perd
    private IEnumerator DeathAnim()
    {
        float duration = 0.1f; // Durée de l'animation en secondes

        Vector3 originalScale = transform.localScale;
        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            float t = timer / duration;

            transform.localScale = Vector3.Lerp(originalScale, Vector3.zero, t);

            yield return null;
        }

        Destroy(gameObject);
    }

    private void Update()
    {
        if (GameManagerD.instance._isGameOn)
        {
            if (!_isShrinking)
            {
                StartCoroutine(ShrinkOverTime(GameManagerD.instance.speedDurationBeforeDie));
            }

            if (Input.GetMouseButtonDown(0) && !IsPointerOverUIObject())
            {
                GameManagerD.instance.ResetScore();
            }
        }
    }

    private IEnumerator ShrinkOverTime(float duration)
    {
        _isShrinking = true;
        Vector3 originalScale = transform.localScale;
        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            float t = timer / duration;
            transform.localScale = Vector3.Lerp(originalScale, Vector3.zero, t);
            yield return null;
        }

        if (transform.localScale == Vector3.zero)
        {
            GameManagerD.instance.ResetScore();
            Destroy(gameObject);
        }

        _isShrinking = false;
    }


    private bool IsPointerOverUIObject()
    {
        // Vérifie si le pointeur de la souris est sur un objet UI
        return EventSystem.current.IsPointerOverGameObject();
    }
}
