using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasFaceCamera : MonoBehaviour
{
    private void LateUpdate() => transform.LookAt(Camera.main.transform);
    
}
