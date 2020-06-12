using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject PauseMenu;


    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Stop();
        }
    }

    public void Stop()
    {
        A_.Activate(PauseMenu);
        StaticVals.isPaused = true;
    }

    public void Resume()
    {
        A_.DeActivate(PauseMenu);
        StaticVals.isPaused = false;
    }
}
