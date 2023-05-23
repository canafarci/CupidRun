using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoupleStart : CharacterStart
{
    [SerializeField] AnimatorEnums _characterType;
    StartPositioner _positioner;
    

    public static event Action OnMaleInPosition;
    private void OnEnable() => ContextGate.OnContextGatePassed += OnContextGatePass;
    private void OnDisable() => ContextGate.OnContextGatePassed -= OnContextGatePass;

    protected override void Awake()
    {
        base.Awake();
        _positioner = GetComponent<StartPositioner>();
        SetAnimatorReferences();
    }

    protected void OnContextGatePass()
    {
        GameManager.Instance.AnimationManager.MaleAnimator.Play("male_walk");
        GameManager.Instance.AnimationManager.FemaleAnimator.Play("catwalk");

        StartCoroutine(PositioningRoutine());
    }

    IEnumerator PositioningRoutine()
    {
        StartCoroutine(_positioner.RotateValentine());
        yield return StartCoroutine(_positioner.MoveValentine());
        ValentineInPosition();
    }
    void ValentineInPosition()
    {
        _fullBodyBipedIK.enabled = true;
        _holdHands.enabled = true;
    }

    private void SetAnimatorReferences()
    {
        if (_characterType == AnimatorEnums.Male)
            GameManager.Instance.AnimationManager.MaleAnimator = transform.GetComponentInChildren<Animator>();
        else
            GameManager.Instance.AnimationManager.FemaleAnimator = transform.GetComponentInChildren<Animator>();
    }
}
