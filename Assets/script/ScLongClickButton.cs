using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScLongClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler{
    private Animator _animator;
    private bool pointerDown;
    private float pointerDownTimer;
    Image image;

    public float requiredHoldTime;

    public UnityEvent StartLongClickEvent;
    public UnityEvent onLongClick;
    public UnityEvent CanceledLongClickEvent;


    private void OnEnable(){
        _animator = GetComponent<Animator>();
    }

    public void OnPointerDown(PointerEventData eventData){
        pointerDown = true;
        StartLongClickEvent?.Invoke();
         _animator.SetBool("Clics", true);
    }

    public void OnPointerUp(PointerEventData eventData){
        if (pointerDown)
        {
            _animator.SetBool("Clics", false);
            CanceledLongClickEvent?.Invoke();
            Reset();
        }
        
    }

    void Update(){
        if (pointerDown) {
            pointerDownTimer += Time.deltaTime;
            if(pointerDownTimer > requiredHoldTime) {
                if (onLongClick != null) { onLongClick.Invoke(); }
                Reset();
            }
        }
    }

    private void Reset() {
        pointerDown = false;
        pointerDownTimer = 0;
        _animator.SetBool("Clics", false);
    }
}
