using UnityEngine;
using System.Collections.Generic;

// Simple BoardController scaffold: handles input and coordinates pieces on a 3D board.
public class BoardController : MonoBehaviour
{
    public Transform boardRoot; // parent for squares/pieces
    public Camera mainCamera;

    private Vector3 dragStart;
    private bool isDragging = false;

    void Start()
    {
        if (mainCamera == null) mainCamera = Camera.main;
    }

    void Update()
    {
        HandleTouchInput();
    }

    void HandleTouchInput()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            dragStart = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            // TODO: raycast from camera to board and send selected square
        }
#else
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                isDragging = true;
                dragStart = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                isDragging = false;
                // TODO: raycast and handle tap
            }
        }
#endif
    }
}
