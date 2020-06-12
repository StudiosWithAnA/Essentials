using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorFollow : MonoBehaviour
{
    [SerializeField] private Texture2D[] CursorTex;
    [SerializeField] private Texture2D reloadTex;
    [SerializeField] private int frameCount;
    [SerializeField] private float frameRate;

    private int currentFrame;
    private float frameTimer;

    public bool isReloading = false;

    void Start()
    {
        Cursor.SetCursor(CursorTex[0], new Vector2(0.25f, 0.25f), CursorMode.Auto);
    }

    
    void Update()
    {
        if (isReloading == false)
        {
            frameTimer -= Time.deltaTime;
            if (frameTimer <= 0f)
            {
                frameTimer = frameRate;
                currentFrame = (currentFrame + 1) % frameCount;
                Cursor.SetCursor(CursorTex[currentFrame], new Vector2(0.25f, 0.25f), CursorMode.Auto);
            }
        }
        if(isReloading == true)
        {
            Cursor.SetCursor(reloadTex, new Vector2(0, 0), CursorMode.Auto);
        }
    }

    
}
