using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AnimationManager : MonoBehaviour
{
    [HideInInspector] public Animator CupidAnimator, MaleAnimator, FemaleAnimator;

    Queue<IEnumerator> _queue = new Queue<IEnumerator>();
    Coroutine _queueRoutine = null;
    public static event Action<AlignmentType> OnChangeAnimation;

    public void EnqueueAnimation(AnimatorEnums animatorEnum, string animationToPlay, bool changeAnimation = false)
    {
        _queue.Enqueue(AnimationRoutine(animatorEnum, animationToPlay, changeAnimation));

        if (_queueRoutine == null)
            _queueRoutine = StartCoroutine(ExecuteQueue());
    }

    public void EnqueueRoutine(IEnumerator routine)
    {
        _queue.Enqueue(routine);

        if (_queueRoutine == null)
            _queueRoutine = StartCoroutine(ExecuteQueue());
    }

    private IEnumerator ExecuteQueue()
    {
        while (_queue.Count > 0)
        {
            yield return StartCoroutine(_queue.Dequeue());
        }
        _queueRoutine = null;
    }


    IEnumerator AnimationRoutine(AnimatorEnums animatorEnum, string animationToPlay, bool changeAnimation = false )
    {
        Animator animator = GetAnimator(animatorEnum);
        animator.Play(animationToPlay);

        if (changeAnimation)
        {
            OnChangeAnimation?.Invoke(FindObjectOfType<AlignmentCounter>().CurrentAlignment);
        }
            

        yield return new WaitForSeconds(GetAnimationLength(animationToPlay, animator));
    }

    private Animator GetAnimator(AnimatorEnums animatorEnum)
    {
        switch (animatorEnum)
        {
            case AnimatorEnums.Cupid:
                return CupidAnimator;
            case AnimatorEnums.Female:
                return FemaleAnimator;
            case AnimatorEnums.Male:
                return MaleAnimator;
            default:
                return null;
        }
    }

    public float GetAnimationLength(string name, Animator animator)
    {
        for (int i = 0; i < animator.runtimeAnimatorController.animationClips.Length; i++)
        {
            if (animator.runtimeAnimatorController.animationClips[i].name == name)
                return animator.runtimeAnimatorController.animationClips[i].length;
        }

        Debug.LogError("Animation clip: " + name + " not found");
        return 0;
    }
}
