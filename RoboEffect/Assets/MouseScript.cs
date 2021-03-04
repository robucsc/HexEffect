using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScript : MonoBehaviour
{
    private bool isDragging;
    private Vector2 difference;
    
    public void OnMouseDown(){
        Debug.Log("mouse down");

        isDragging = true;
        difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    }

    public void OnMouseUp()
    {
        isDragging = false;
    }

    private void Update()
    {
        if (isDragging)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePos - difference);
        }
    }
}
