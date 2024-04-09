using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private GameObject GameManager;
    [SerializeField] private GameObject Anim;
    private void Start()
    {
        transform.localPosition = new Vector3(Random.Range(-896, 896), Random.Range(-476, 476), transform.localPosition.z);
    }
    public void MoveButton()
    {
        Instantiate(Anim, transform.position,Quaternion.identity);
        transform.localPosition = new Vector3(Random.Range(-896, 896), Random.Range(-476, 476),transform.localPosition.z);
        GameManager.GetComponent<GameManager>().Score++;
        GameManager.GetComponent<GameManager>().Timer += 1*0.75f;
    }
}
