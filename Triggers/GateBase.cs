using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GateBase : MonoBehaviour
{
    protected BoxCollider _boxCollider;
    protected GateFX _gateFX;
    protected Animator _animator;

    protected abstract void OnTriggerEnter(Collider other);
}
