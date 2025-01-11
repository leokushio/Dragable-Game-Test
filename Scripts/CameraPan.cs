using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static DragableSprite;

public class CameraPan : MonoBehaviour
{
    [SerializeField] private Camera cam;

    private bool isCamDragging = false;
    private Vector3 dragStart;

    
    void Update()
    {
        if(DragableSprite.isDragging == false)
            PanCamera(); 
    }

    private void PanCamera()
    {
        if(Input.GetMouseButtonDown(0))
        {
            dragStart = cam.ScreenToWorldPoint(Input.mousePosition);
        }
        if(Input.GetMouseButton(0))
        {
            Vector3 diff = dragStart - cam.ScreenToWorldPoint(Input.mousePosition);
            diff.z = 0;
            diff.y = 0;
            cam.transform.position += diff;
        }
    }
}
