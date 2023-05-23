using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextGate : GateBase
{
    public static event Action OnContextGatePassed;

    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider>();
    }
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Couple"))
        {
            _boxCollider.enabled = false;
            OnContextGatePassed?.Invoke();
        }
    }
}
