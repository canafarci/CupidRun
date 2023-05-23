using RootMotion.FinalIK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldHands : MonoBehaviour
{
    [SerializeField] Transform _holdHandPosition;
    FullBodyBipedIK _fullBodyBipedIK;

    private void Awake() => _fullBodyBipedIK = GetComponent<FullBodyBipedIK>();

    private void Start() => _fullBodyBipedIK.solver.rightHandEffector.target = _holdHandPosition;
}

