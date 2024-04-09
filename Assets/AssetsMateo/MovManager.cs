using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MovManager : MonoBehaviour
{
    int life = 3;
    int score = 3; 
    public static MovManager instance;
    public Canvas Win;
    public Canvas lose;
    public GameObject cubePrefab;
    public Transform parentCanvas;

    private Coroutine timerCoroutine;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            DestroyImmediate(gameObject);
    }

    void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        Vector3 position = new Vector3(Random.Range(-600f, 600f), Random.Range(-600f, 600f), 0);
        GameObject cube = Instantiate(cubePrefab, position, Quaternion.identity);
        cube.transform.SetParent(parentCanvas, false);


        StartCoroutine(ClickTimer(cube));
     
    }

    IEnumerator ClickTimer(GameObject cube)
    {
        yield return new WaitForSeconds(0.75f);
        Remove(cube);

        life--;
    }

  

    public void Remove(GameObject cube)
    {
        Destroy(cube);
        StopAllCoroutines();
        score++;

        if (score >= 30)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            Spawn();
        }

        if (life <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
