using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshot : MonoBehaviour
{
    static int _ssIndex;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            ScreenCapture.CaptureScreenshot($"ss/ss{_ssIndex}.png");
            _ssIndex++;
        }
    }
}
