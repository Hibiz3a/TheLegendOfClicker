using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerD : MonoBehaviour
{
    public static GameManagerD instance;

    [Header("Difficulty")]
    public float speedDurationBeforeDie = 10;
    public bool _isGameOn = false;

    [Header("Parameters")]
    [SerializeField] private List<GameObject> _prefabCube;
    [SerializeField] private Canvas _canvas;
    private RectTransform _canvasRectTransform;
    
    [Header("Canvas Finish")]
    [SerializeField] private GameObject _victoryCanvas;
    [SerializeField] private GameObject _defeatCanvas;

    [Header("Score")]
    [SerializeField] private TextMeshProUGUI _scoreText; // Référence au texte affichant le score  
    private int _score = 0;



    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            DestroyImmediate(gameObject);

        _canvasRectTransform = _canvas.GetComponent<RectTransform>();
    }

    void Start()
    {
        _scoreText.text = "Score : " + _score.ToString();
        SpawnCube();
    }

    private void Update()
    {
        UpdateFinish();
    }

    public void SpawnCube()
    {
        speedDurationBeforeDie = 10;
        int indexPrefab = Random.Range(0, _prefabCube.Count);
        RectTransform prefabCubeRectTransform = _prefabCube[indexPrefab].GetComponent<RectTransform>(); // Obtenez le RectTransform du prefabCube

        float canvasWidth = _canvasRectTransform.rect.width;
        float canvasHeight = _canvasRectTransform.rect.height;

        float randomX = Random.Range(-canvasWidth / 2f + prefabCubeRectTransform.rect.width / 2f, canvasWidth / 2f - prefabCubeRectTransform.rect.height / 2f);
        float randomY = Random.Range(-canvasHeight / 2f + prefabCubeRectTransform.rect.width / 2f, canvasHeight / 2f - prefabCubeRectTransform.rect.height / 2f);
        Vector3 randomPosition = new Vector3(randomX, randomY, 0);

        GameObject cube = Instantiate(_prefabCube[indexPrefab], randomPosition, Quaternion.identity);
        cube.transform.SetParent(_canvas.transform, false);
    }

    public void AddScore()
    {
        _score++;
        UpdateScoreText();
    }
    public void ResetScore()
    {
        /*_score = 0;
        UpdateScoreText();*/

            // defeat

        if (_defeatCanvas != null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //StartCoroutine(WaitToSwitchScene(1, -1));
        }
    }

    private void UpdateScoreText()
    {
        if (_scoreText != null)
        {
            _scoreText.text = "Score : " + _score.ToString();
        }
    }

    private void UpdateFinish()
    {
        if (_score >= 15)
        {
            if (_victoryCanvas != null)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

                //StartCoroutine(WaitToSwitchScene(1, 1));
            }
        }
    }

    public IEnumerator WaitToSwitchScene(float duration, int sceneIndexOffset)
    {
        yield return new WaitForSeconds(duration);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + sceneIndexOffset);
    }
}