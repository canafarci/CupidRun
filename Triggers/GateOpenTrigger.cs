using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class GateOpenTrigger : MonoBehaviour
{
    [SerializeField] Animator _leftDoorAnimator, _rightDoorAnimator;
    BoxCollider _boxCollider;
    private void Awake() => _boxCollider = GetComponent<BoxCollider>();
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Couple"))
        {
            _boxCollider.enabled = false;
            _leftDoorAnimator.enabled = true;
            _rightDoorAnimator.enabled = true;

        }

    }
}
