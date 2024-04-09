using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerDragonCave : MonoBehaviour
{
    public static GameManagerDragonCave Instance;

    public float StartTimer = 30;
    public float Timer = 30;
    public int Score = 0;
    public int ScoreToBeat = 30;

    [SerializeField] private GameObject _coin;
    [SerializeField] private GameObject _explosionSprite;
    [SerializeField] private GameObject _cubeClickParticle;

    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private Transform _canvas;

    [SerializeField] private GameObject _finalCanvas;

    private void Awake()
    {
        Instance = this;
        Timer = StartTimer;
    }

    private void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        if (Score >= ScoreToBeat)
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else 
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);
        }

        _finalCanvas.GetComponent<CanvasGroup>().alpha = 1;
        _finalCanvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Score done: " + Score.ToString();

        Timer = StartTimer;
        Score = 0;
    }

    public void CubeClicked(GameObject cube)
    {
        Instantiate(_cubeClickParticle, Camera.main.ScreenToWorldPoint(cube.transform.position) + Vector3.forward * 10, Quaternion.identity);

        Instantiate(_explosionSprite, _canvas).GetComponent<RectTransform>().localPosition = cube.GetComponent<RectTransform>().localPosition;

        GameObject coin = Instantiate(_coin, _canvas);
        coin.GetComponent<RectTransform>().localPosition = cube.GetComponent<RectTransform>().localPosition;
        Destroy(coin, 0.5f);

        Destroy(cube);
        SpawnCube(Vector2.zero);
        Score++;
        SoundManager.Instance.PlayAtPath("ping");
    }

    public void SpawnCube(Vector2 pos)
    {
        if (pos == Vector2.zero)
        {
            pos = new Vector2(Random.Range(-960 + (128 / 2), 960 - (128 / 2)), Random.Range(-540 + (128 / 2), 540 - (128 / 2)));
        }
        GameObject cube = Instantiate(_cubePrefab, _canvas);
        cube.GetComponent<RectTransform>().localPosition = pos;
        //cube.GetComponent<Image>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
    }
}
