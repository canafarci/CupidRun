using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAnimation : MonoBehaviour
{
    AlignmentCounter _alignmentCounter;
    EndPunch _endPunch;
    EndFX _endFX;

    [SerializeField] float _firstDelay, _secondDelay;

    private void Awake()
    {
        _alignmentCounter = FindObjectOfType<AlignmentCounter>();
        _endPunch = GetComponent<EndPunch>();
        _endFX = GetComponent<EndFX>();
    }

    public void EndGameAnimation()
    {
        if (_alignmentCounter.CurrentAlignment == AlignmentType.Good)
            GoodEnding();
        else
            StartCoroutine(BadEnding());
    }

    IEnumerator BadEnding()
    {
        GameManager.Instance.AnimationManager.FemaleAnimator.SetBool("GameEnd", true);
        GameManager.Instance.AnimationManager.MaleAnimator.SetBool("GameEnd", true);
        _endFX.PlayBadFX();
        GameManager.Instance.AnimationManager.FemaleAnimator.Play(AnimationStrings.Argue);

        yield return new WaitForSeconds(_firstDelay);
        
        GameManager.Instance.AnimationManager.MaleAnimator.Play(AnimationStrings.MaleIdle);
        GameManager.Instance.AnimationManager.FemaleAnimator.Play(AnimationStrings.Punch);

        foreach (Rotator _rot in GetComponentsInChildren<Rotator>())
        {
            _rot.enabled = false;
        }
        
        yield return new WaitForSeconds(_secondDelay);
        _endPunch.SlapRagdoll();
    }

    private void GoodEnding()
    {
        _endFX.PlayGoodFX();

        GameManager.Instance.AnimationManager.MaleAnimator.SetBool("GameEnd", true);
        GameManager.Instance.AnimationManager.MaleAnimator.Play(AnimationStrings.Kissing);
        GameManager.Instance.AnimationManager.FemaleAnimator.SetBool("GameEnd", true);
        GameManager.Instance.AnimationManager.FemaleAnimator.Play(AnimationStrings.Kissing);
    }

    
}
