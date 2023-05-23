using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetMover : MonoBehaviour
{
    [SerializeField] Transform _targetTransform;
    [SerializeField] float _offset;

    private void OnEnable() => CoupleEndGameBehaviour.OnEndGameOffset += EndGameOffset;
    private void OnDisable() => CoupleEndGameBehaviour.OnEndGameOffset -= EndGameOffset;

    private void EndGameOffset()
    {
        StartCoroutine(MoveToPositionOffset());
    }

    IEnumerator MoveToPositionOffset()
    {
        while (Vector3.Distance(transform.localPosition, _targetTransform.localPosition) > _offset)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, _targetTransform.localPosition, Time.deltaTime * 5f);
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
