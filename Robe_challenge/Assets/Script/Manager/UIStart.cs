using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStart : MonoBehaviour
{
    public Canvas canvas;

    void Start()
    {
        UIManager.Instance.OpenUI<Menu>();

        canvas = GetComponent<Canvas>();
    }

    void Update()
    {

        // Đảm bảo chế độ render của Canvas luôn là ScreenSpace
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        if (canvas.worldCamera == null)
        {
            // Tìm Main Camera trong scene nếu renderCamera bị null
            canvas.worldCamera = Camera.main;
        }
    }
}
