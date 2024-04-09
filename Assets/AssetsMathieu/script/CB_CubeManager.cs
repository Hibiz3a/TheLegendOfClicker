using UnityEngine;

public class CB_CubeManager : MonoBehaviour
{
    [SerializeField]
    private GameObject cube;
    [SerializeField]
    private int timer;
    [SerializeField]
    private float timeCoolDown;
    [SerializeField]
    private int numberOfCube;
    [SerializeField]
    private Canvas canvas;



    public int NumberOfCube
    {
        get { return numberOfCube; }
        set { numberOfCube = value; }
    }


    public static CB_CubeManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        timeCoolDown = timer;
    }

    private void FixedUpdate()
    {
        if (timeCoolDown < 0)
        {
            Spawn(); 
            timeCoolDown = timer;
        }
        else
        {
            timeCoolDown -= Time.fixedDeltaTime;
        }
    }

    private void Spawn()
    {
        for (int i = 0; i < numberOfCube; i++)
        {
            Vector2 pos = new Vector2(Random.Range(64, canvas.transform.position.x-64), Random.Range(64, canvas.transform.position.y-64));
            GameObject obj = Instantiate(cube, pos, Quaternion.identity);
            obj.transform.SetParent(canvas.transform);
        }
    }


}
    