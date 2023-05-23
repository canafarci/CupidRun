using Dreamteck.Splines;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEndGameBehaviour : EndGameBehaviour
{
    [SerializeField] SplineComputer _splineComputer;
    [SerializeField] float _flySpeed;
    private bool _firstStage = true;

    private void OnEnable() => CoupleEndGameBehaviour.OnEndGameFinish += OnCoupleFinished;
    private void OnDisable() => CoupleEndGameBehaviour.OnEndGameFinish -= OnCoupleFinished;

    public void OnEndGameReached()
    {
        if (_firstStage)
            FirstStage();
        else
            SecondStage();
    }

    private void FirstStage()
    {
        DisablePathFollower();
        StartCoroutine(MoveToPosition(2.5f));
        StartCoroutine(ResetLocalXPosition());
        FindObjectOfType<PlayerMover>().enabled = false;
        _firstStage = false;
    }

    void SecondStage()
    {
        GameManager.Instance.AnimationManager.CupidAnimator.SetTrigger(AnimationStrings.DanceTrigger);
        GameManager.Instance.CameraController.ActivateCamera(CameraStrings.EndGameCamera);
        EndGameCanvasRoutine();
    }

    protected override IEnumerator MoveToPosition(float slowAmount)
    {
        yield return base.MoveToPosition(slowAmount);
        GameManager.Instance.AnimationManager.CupidAnimator.Play(AnimationStrings.CupidIdle);
    }

    void OnCoupleFinished()
    {
        StartCoroutine(GameEnd());
    }

    IEnumerator GameEnd()
    {
        yield return new WaitForSeconds(2f);
        EnablePathFollower();
        _splineFollower.spline = _splineComputer;
        _splineFollower.Restart();
        _splineFollower.followSpeed = _flySpeed;
        GameManager.Instance.AnimationManager.CupidAnimator.SetTrigger(AnimationStrings.FlyTrigger);
        GameManager.Instance.CameraController.ActivateCamera(CameraStrings.FlyCamera);
    }
}
