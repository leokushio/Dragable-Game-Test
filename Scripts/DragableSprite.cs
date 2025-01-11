using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragableSprite : MonoBehaviour
{
    public static bool isDragging = false;

    public Rigidbody2D rb;
    public PolygonCollider2D floor;
    public PolygonCollider2D[] surface;
    public BoxCollider2D footerCollider;
    // public GameObject footer;

    public void OnMouseDown()
    {
        isDragging = true;
        transform.localScale = new Vector3(0.23f, 0.23f, 0.23f);
        rb.gravityScale = 0f;
    }

    public void OnMouseUp()
    {
        isDragging = false;
        transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);   
    }

    void Update()
    {
        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = transform.position.z;
            transform.position = mousePosition;
        }  

        UpdateGravity(); 
    }

    private void UpdateGravity()
    {
        if (IsAboveSurfaces())
        {
            rb.gravityScale = 0f;
            rb.velocity = Vector2.zero;
        }
        else
        {
            rb.gravityScale = 1f;
        }
    }

    private bool IsAboveSurfaces()
    {
        if (surface == null || surface.Length == 0)
        {
            return false;
        }
        
        for (int i = 0; i < surface.Length; i++)
        {
            if (surface[i] != null && surface[i].IsTouching(footerCollider))
            {
                return true;
            }
        }     
        return false;
    }
}
