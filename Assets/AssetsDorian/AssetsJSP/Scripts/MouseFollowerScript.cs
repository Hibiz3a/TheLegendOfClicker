using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseFollowerScript : MonoBehaviour
{
    public GameObject dakube;
    public List<Sprite> cubeSprites = new List<Sprite>();
    public List<GameObject> deadSprites = new List<GameObject>();
    public SpriteRenderer spriteRenderer;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    private int clickNumber;
    private float timer = 20;

    private void Start()
    {
        timer = 20;
    }

    private void Update()
    {
        timer -= Time.fixedDeltaTime;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.gameObject.transform.position = mousePosition;
        scoreText.text = "Bottles Exploded : " + clickNumber.ToString() + " / 30";
        timerText.text = "Timer : " + Mathf.Round(timer).ToString();
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null && hit.collider.CompareTag("DAKUBE") && Input.GetMouseButtonDown(0))
        {
            timer = 20;
            TeleportDakube();
            int spriteIndex = SelectRandomSprite();
            if (spriteIndex >= 0 && spriteIndex < deadSprites.Count)
            {
                GameObject deadSpritePrefab = deadSprites[spriteIndex];
                if (deadSpritePrefab != null)
                {
                    GameObject newDeadSprite = Instantiate(deadSpritePrefab, dakube.transform.position, Quaternion.identity);
                    newDeadSprite.SetActive(true);
                }
            }
            clickNumber++;
        }

        if (clickNumber == 30)
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex + 1);
        }

        if (timer <= 0)
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex - 1);
        }
    }

    private void TeleportDakube()
    {
        Vector3 randomPosition = new Vector3(Random.Range(8, -8), Random.Range(4, -4), 0);
        dakube.transform.position = randomPosition;
    }

    private int SelectRandomSprite()
    {
        int randomIndex = Random.Range(0, cubeSprites.Count);
        Sprite selectedSprite = cubeSprites[randomIndex];

        if (selectedSprite == null)
        {
            return -1;
        }
        else
        {
            spriteRenderer.sprite = selectedSprite;
            return randomIndex;
        }
    }
}