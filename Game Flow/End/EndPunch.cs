using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPunch : MonoBehaviour
{
    [SerializeField] GameObject _male, _ragdollMale, _female;
    [SerializeField] Rigidbody _ragdoll;
    [SerializeField] float _ragdollDelay, _ragdollForce;


    public void SlapRagdoll()
    {
        Invoke("OnSlap", _ragdollDelay);
    }
    private void OnSlap()
    {
        _ragdollMale.SetActive(true);
        _ragdollMale.transform.rotation = _male.transform.rotation;
        _male.SetActive(false);

        Vector3 direction = (_female.transform.forward).normalized;

        _ragdoll.AddExplosionForce(5f, _ragdoll.GetComponent<Collider>().ClosestPoint(_female.transform.position), 0.2f);
    }
}
