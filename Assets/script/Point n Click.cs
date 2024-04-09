using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PointnClick : MonoBehaviour
{
    [SerializeField] EventSystem eventSystem;
    [SerializeField] GraphicRaycaster raycaster;
    [SerializeField] string cibleTag;
    [SerializeField] TargetSpawner TargetSpawner;
    [SerializeField] TimerAndHealthManager healthManager;

    private void Update()
    {
        Vector3 MousePos = Input.mousePosition;
        PointerEventData pointerEventData = new PointerEventData(eventSystem);
        pointerEventData.position = MousePos;

        List<RaycastResult> results = new List<RaycastResult>();


        raycaster.Raycast(pointerEventData, results);

        // if the mouse is in an element
        if (results.Count > 0)
        {
            if(Input.GetMouseButtonDown(0) && results[0].gameObject.CompareTag(cibleTag))
            {
                Destroy(results[0].gameObject);
                TargetSpawner.SpawnTarget();
                healthManager.AddTime(0.4f);
                healthManager.AddScore();
            }
            else if (Input.GetMouseButtonDown(0))
            {
                healthManager.loseHealthPoint();
            }
        }
    }
}


