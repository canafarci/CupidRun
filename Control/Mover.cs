using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : MonoBehaviour
{
    [SerializeField] protected float _speed;
    [SerializeField] protected float _lowerRange, _upperRange;
    public abstract void CalculatePosition(float change);

}
