using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_brume : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject m_heartStock;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.Lerp(transform.position, new Vector2(1960, 100), Time.deltaTime);
        if(Vector2.Distance(transform.position, new Vector2(1960, 100)) < 5)
        {
            Grow();
            Destroy(gameObject);
        }
    }
    private void Grow()
    {
        m_heartStock.transform.localScale += new Vector3(0.5f, 0.5f, 1);
    }
}
