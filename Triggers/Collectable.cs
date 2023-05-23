using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public abstract class Collectable : MonoBehaviour, ICollectable
{
    [SerializeField] protected GameObject _vfx;
    [SerializeField] protected AlignmentType _alignmentType;
    [SerializeField] protected float _increaseAmount;
    protected BoxCollider boxCollider;

    virtual protected void Awake() => boxCollider = GetComponent<BoxCollider>();

    public virtual void OnCollected()
    {
        boxCollider.enabled = false;
    }

    protected void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
            OnCollected();
    } 

}
