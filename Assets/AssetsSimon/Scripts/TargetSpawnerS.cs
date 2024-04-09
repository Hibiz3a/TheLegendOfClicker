using UnityEngine;

public class TargetSpawnerS : MonoBehaviour
{
    [SerializeField] private GameObject target;
    private bool isTargetHere;

    private void Start()
    {
        isTargetHere = false;
    }

    private void Update()
    {
        if (!isTargetHere)
        {
            SpawnTarget();
        }
        else if (target.transform.position == null)
        {
            isTargetHere = false;
        }
    }

    public void SpawnTarget()
    {
        Vector2 randPos = new Vector2(Random.Range(-20, 20), Random.Range(-10, 10));
        GameObject.Instantiate(target, randPos, Quaternion.identity);
        isTargetHere = true;
    }
}
