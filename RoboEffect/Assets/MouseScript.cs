using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MouseScript : MonoBehaviour
{

    private Tilemap tilemap;
    private bool isDragging;
    private Vector2 difference;
    private Vector2 mousePos;
    private Vector3Int mouseXYZpos;

    private TileBase tile;
    
    public void OnMouseDown(){
        Debug.Log("mouse down");
        FindObjectOfType<AudioManager>().Play("select");
        isDragging = true;
        difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    }

    public void OnMouseUp()
    {
        FindObjectOfType<AudioManager>().Play("beem");
        isDragging = false;
    }

    private void Start()
    {
        tilemap = GetComponent<Tilemap>();
    }

    private void Update()
    {
        if (isDragging)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePos - difference);
        }
        
        // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // Vector3 worldPoint = ray.GetPoint(-ray.origin.z / ray.direction.z);
        // Vector3Int position = tilemap.WorldToCell(worldPoint);
        //
        // TileBase tile = tilemap.GetTile(position);
        
        
        mouseXYZpos = new Vector3Int((int)Input.mousePosition.x, (int)Input.mousePosition.y , 0 );
        Debug.Log(mouseXYZpos);
        tile = tilemap.GetTile(mouseXYZpos);
        
         // Debug.Log(tile);
        
    }
}

