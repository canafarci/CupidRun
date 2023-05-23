using RootMotion.FinalIK;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStart : MonoBehaviour
{
    protected FullBodyBipedIK _fullBodyBipedIK;
    protected HoldHands _holdHands;

    protected virtual void Awake()
    {
        _holdHands = GetComponent<HoldHands>();
        _fullBodyBipedIK = GetComponent<FullBodyBipedIK>();
    }
}
