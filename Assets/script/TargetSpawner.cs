using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] private GameObject targetPrefab;
    [SerializeField] private GameObject Canva;


    private void Start()
    {
        SpawnTarget();
    }

    public void SpawnTarget()
    {
        GameObject newTarget = Instantiate(targetPrefab);
        newTarget.transform.SetParent(Canva.transform);
        newTarget.transform.position = new Vector2(Random.Range(65, 1850), Random.Range(65, 1015));
        
    }
}
