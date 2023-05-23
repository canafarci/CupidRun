using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class AlignmentGate : GateBase
{
    public AlignmentType GateType;
    [SerializeField] protected string  _maleAnimationToPlay, _femaleAnimationToPlay;
    [SerializeField] float _alignmentChange;
    AlignmentCounter _alignmentCounter; 
    

    private void Awake()
    {
        _alignmentCounter = FindObjectOfType<AlignmentCounter>();
        _boxCollider = GetComponent<BoxCollider>(); 
        _gateFX = GetComponent<GateFX>();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _boxCollider.enabled = false;

            _alignmentCounter.OnAlignmentChange(GateType, _alignmentChange);
            _gateFX.PlayFX();
            PlayAnimations();
        }
    }

    private void PlayAnimations()
    {
        if (_maleAnimationToPlay != null)
            StartCoroutine(PlayAnimation(GameManager.Instance.AnimationManager.MaleAnimator));
        if (_femaleAnimationToPlay!= null)
            StartCoroutine(PlayAnimation(GameManager.Instance.AnimationManager.FemaleAnimator));
    }

    IEnumerator PlayAnimation(Animator animator)
    {
        animator.SetLayerWeight(1, 1);
        //animator.Play(_maleAnimationToPlay);
        yield return new WaitForSeconds(1.5f);//where start layers??
        animator.SetLayerWeight(1, 0);
    }
}
