using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScHooverImage : MonoBehaviour,  IPointerEnterHandler, IPointerExitHandler {
    public bool isHoovered;

    public void OnPointerEnter(PointerEventData eventData){
        isHoovered = true;
    }

    public void OnPointerExit(PointerEventData eventData) {
        isHoovered=false;
    }
}
