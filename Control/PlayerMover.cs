using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : Mover
{
    InputReader _inputReader;

    private void Awake() => _inputReader = GetComponent<InputReader>();
    private void Update()
    {
        CalculatePosition(_inputReader.ReadInput());
    }

    public override void CalculatePosition(float change)
    {
        float readValue = change * Time.deltaTime * _speed;

        if (transform.localPosition.x + readValue < _lowerRange || transform.localPosition.x + readValue > _upperRange) return;

        Vector3 intermediateVector = transform.localPosition;
        intermediateVector.x += readValue;
        transform.localPosition = intermediateVector;
    }
}

