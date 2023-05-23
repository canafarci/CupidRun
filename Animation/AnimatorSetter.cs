using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorSetter : MonoBehaviour
{
    private void Awake() => GameManager.Instance.AnimationManager.CupidAnimator = GetComponent<Animator>();
}
