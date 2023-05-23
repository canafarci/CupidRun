using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] FloatingJoystick _joystick;
    private void Update() => ReadInput();
    public float ReadInput() => _joystick.Horizontal;
}
