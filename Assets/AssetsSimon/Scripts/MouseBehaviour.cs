using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBehaviour : MonoBehaviour
{
    void Update()
    {
        Vector2 mousePos = Input.mousePosition;
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Debug.Log(Physics.Raycast(new Vector3(mousePos.x, mousePos.y, -100), Vector3.forward, Mathf.Infinity));
            if (Physics.Raycast(new Vector3 (mousePos.x, mousePos.y, -100), Vector3.forward, out hit, Mathf.Infinity))
            {
                Debug.Log(mousePos);
                Destroy(hit.collider.gameObject);
            }
        }
    }
}
