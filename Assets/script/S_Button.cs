using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class S_Button : MonoBehaviour
{
    // Start is called before the first frame update
    private TextMeshProUGUI lives;
    
    [SerializeField]
    private TextMeshProUGUI score;

    [SerializeField]
    private TextMeshProUGUI gameOver;

    [SerializeField]
    private GameObject PBbrume;

    [SerializeField]
    private GameObject stock;

    [SerializeField]
    private Transform stockBrume;
    private int nb_lives;
    private int nb_score;
    private float timer = 0;
    void Start()
    {
        nb_score = 0;
        nb_lives = 3;
        lives=GetComponentInChildren<TextMeshProUGUI>();
        updateLives();
    }

    private IEnumerator end()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2)
        {
            transform.position = new Vector2(Random.Range(128, 1920), Random.Range(128, 1080));
            nb_lives--;
            updateLives();
            timer=0;
            if (nb_lives == 0)
            {
                gameOver.gameObject.SetActive(true);
                gameObject.SetActive(false);
                
            }
        }
        
    }
    public void click()
    {
        transform.position=new Vector2(Random.Range(128, 1920), Random.Range(128, 1080));
        GameObject newBrume = Instantiate(PBbrume,transform.position,Quaternion.identity,stockBrume);
        newBrume.GetComponent<S_brume>().m_heartStock=stock;
        timer = 0;
        nb_score++;
        updateScore();
    }
    private void updateLives()
    {
        lives.text = nb_lives.ToString();
    }
    private void updateScore()
    {
        score.text ="Score : " + nb_score;
    }

}
