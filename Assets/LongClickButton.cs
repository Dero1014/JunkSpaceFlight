using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class LongClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    private bool pointerDown;
    private bool triggered;
    private float pointerDownTimer;

    public float requiredHoldTime;

    public UnityEvent onLongClick;

    public Image redColor;

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Reset();
        if (!triggered)
        {
            colSave.a = 1;
            redColor.color = colSave;
        }
        else
        {
            Invoke("ResetColor", 1f);
        }
    }

    Color colSave;
    void Update()
    {
        if (pointerDown)
        {
            //change color
            colSave = redColor.color;
            colSave.a = 1 - pointerDownTimer/requiredHoldTime;
            redColor.color = colSave;

            pointerDownTimer += Time.deltaTime;
            if (pointerDownTimer >= requiredHoldTime)
            {
                if (onLongClick != null)
                    onLongClick.Invoke();

                triggered = true;

                Reset();
            }
        }
    }

    void Reset()
    {
        pointerDown = false;
        pointerDownTimer = 0;
    }
    
    void ResetColor()
    {
        colSave.a = 1;
        redColor.color = colSave;
    }

    
}
