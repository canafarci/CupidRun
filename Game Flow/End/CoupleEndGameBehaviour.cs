using RootMotion.FinalIK;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoupleEndGameBehaviour : EndGameBehaviour
{
    EndAnimation _endAnimation;
    EndFX _endFX;

    public static event Action OnEndGameRotate;
    public static event Action OnEndGameOffset;
    public static event Action OnEndGameFinish;

    protected override void Awake()
    {
        base.Awake();
        _endAnimation = GetComponent<EndAnimation>();
        _endFX = GetComponent<EndFX>();
    }

    public void OnEndGameReached()
    {
        GameManager.Instance.CameraController.ActivateCamera(CameraStrings.EndPlatformCamera);
        DisablePathFollower();
        StartCoroutine(ResetLocalXPosition());
        StartCoroutine(MoveToPosition(5f));

        OnEndGameRotate?.Invoke();
        DisableIK();
    }

    protected override IEnumerator MoveToPosition(float slowAmount)
    {
        yield return base.MoveToPosition(slowAmount);
        OnEndGameOffset?.Invoke();
        _endAnimation.EndGameAnimation();
        yield return new WaitForSeconds(2f);
        OnEndGameFinish?.Invoke();
        yield return new WaitForSeconds(1f);
        _endFX.ActivateConfetti();
    }
    private void DisableIK()
    {
        foreach (FullBodyBipedIK ik in FindObjectsOfType<FullBodyBipedIK>())
        {
            ik.enabled = false;
        }
    }
}
