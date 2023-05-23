using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoupleMover : Mover
{
    [SerializeField] GameObject _player;

    private void Update() => CalculatePosition(_player.transform.localPosition.x);
        
    public override void CalculatePosition(float change)
    {
        Vector3 intermediateTransform = transform.localPosition;
        intermediateTransform.x = change;
        Vector3 lerpedPosition = Vector3.Lerp(transform.localPosition, intermediateTransform, _speed * Time.deltaTime );

        if (lerpedPosition.x < _lowerRange || lerpedPosition.x > _upperRange) return;

        transform.localPosition = lerpedPosition;        
    }
}