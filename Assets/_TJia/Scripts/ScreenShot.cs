using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShot : MonoBehaviour
{

    public float Duration = 2;
    public bool TakePhotos = false;
    public float FPS = 25;

    private float Timer = 0;
    private float FPSTimer = 0;

    private int mCpt = 0;
    private bool Finished = true;

    internal void TakeAPhoto()
    {
        mCpt++;
        ScreenCapture.CaptureScreenshot("Screenshot" + mCpt + ".png");
    }

    void Update()
    {
        //连续截图，用于制作gif文件
        if (TakePhotos == true)
        {
            Timer = Time.time + Duration;
            TakePhotos = false;
            Finished = false;
        }
        if (Time.time < Timer)
        {
            if (Time.time > FPSTimer)
            {
                FPSTimer = Time.time + 1 / FPS;
                TakeAPhoto();
            }
        }
        else if (Finished == false)
        {
            Finished = true;
            Debug.Log("Finished");
        }

    }
}
