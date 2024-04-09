using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sc_Raiponce : MonoBehaviour
{
    public List<UnityEngine.UI.Image> _hairImages = new List<UnityEngine.UI.Image>();
    private int numClick = -1;
    private float totalTime = 5;

    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject defeatPanel;
    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private GameObject Aura;
    [SerializeField] private GameObject PrinceAura;

    private void Update()
    {
        totalTime -= Time.deltaTime;
        if (totalTime <= 0)
        {
            Defeat();
        }
        UpdateText();
    }
    public void PrincessButton()
    {
        StartCoroutine(AddHair());
    }

    private IEnumerator AddHair()
    {
        numClick++;
        _hairImages[numClick].GetComponent<UnityEngine.UI.Image>().color = new Color32(255, 255, 255, 255);
        Victory();
        Aura.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        Aura.SetActive(false);
    }

    private void Victory()
    {
        if (numClick >= _hairImages.Count - 1)
        {
            Time.timeScale = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void UpdateText()
    {
        int Timer = (int)totalTime;
        timerText.text = Timer.ToString();
    }

    private void Defeat()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
