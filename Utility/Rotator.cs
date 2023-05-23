using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] Transform _targetTransform;

    //values for internal use
    private Quaternion _lookRotation;
    private Vector3 _direction;

    private void OnEnable() => CoupleEndGameBehaviour.OnEndGameRotate += EndGameRotate;
    private void OnDisable() => CoupleEndGameBehaviour.OnEndGameRotate -= EndGameRotate;

    public void StartRotate(Transform target)
    {
        StartCoroutine(Rotate(target));
    }
    private void EndGameRotate()
    {
        StartCoroutine(Rotate(_targetTransform));
    }

    IEnumerator Rotate(Transform targetTransform)
    {
        // find the vector pointing from our position to the target
        _direction = (targetTransform.localPosition - transform.localPosition).normalized;

        //create the rotation we need to be in to look at the target
        _lookRotation = Quaternion.LookRotation(_direction);

        for (float x = 0; x < 1f; x += Time.deltaTime)
        {
            //rotate us over time according to speed until we are in the required rotation
            transform.localRotation = Quaternion.Slerp(transform.localRotation, _lookRotation, x);

            yield return new WaitForSeconds(Time.deltaTime * 10f);
        }
        yield return null;
    }
}
