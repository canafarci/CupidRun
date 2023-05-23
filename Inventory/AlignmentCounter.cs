using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignmentCounter : MonoBehaviour
{
    private AlignmentType _currentAlignment;
    public AlignmentType CurrentAlignment { get { return _currentAlignment; } }
    [SerializeField] float _alignmentPoints;
    int _currentAlignmentIndex;

    PlayerChange _playerChange;
    AlignmentCanvas _alignmentCanvas;

    public static event Action OnSliderChange;
    public static event Action<AlignmentType> OnAlignmentReversEvent;

    private void Awake()
    {
        _playerChange = GetComponent<PlayerChange>();
        _alignmentCanvas = FindObjectOfType<AlignmentCanvas>();
        _alignmentPoints = 0.5f;
    }

    private void OnEnable() => AlignmentSlider.OnSliderChange += OnSliderChangeItems;
    private void OnDisable() => AlignmentSlider.OnSliderChange -= OnSliderChangeItems;

    private void Start() => _currentAlignment = AlignmentType.Neutral;

    public void OnAlignmentChange(AlignmentType alignment, float change)
    {

        if (_currentAlignment == AlignmentType.Neutral)
        {
            NeutralAlignmentPickup(alignment, change);
            return;
        }

        float alteredAmount = (_currentAlignment == alignment) ? change : change * -1;

        if (_alignmentPoints + alteredAmount <= 0 && !(_currentAlignmentIndex == 0))
            OnAlignmentSliderDown(_alignmentPoints = _alignmentPoints + alteredAmount + 1f);

        else if (_alignmentPoints + alteredAmount >= 1)
            OnAlignmentSliderUp(_alignmentPoints = _alignmentPoints + alteredAmount - 1f);

        else if (_alignmentPoints + alteredAmount <= 0 && _currentAlignmentIndex == 0)
            OnAlignmentReverse(alteredAmount);

        else
            RegularAlignmentChange(alteredAmount);
    }

    private void RegularAlignmentChange(float alteredAmount)
    {
        _alignmentPoints += alteredAmount;
        CalculateSliderQueue(_alignmentPoints);
    }

    void NeutralAlignmentPickup(AlignmentType alignment, float change)
    {
        float alteredAmount = (alignment == AlignmentType.Good) ? change : (change * -1f);

        if (_alignmentPoints + alteredAmount >= 1)
        {
            FirstTimeAlignmentChange(alignment);
            OnAlignmentSliderUp(_alignmentPoints = _alignmentPoints + alteredAmount - 1f, true);
            return;
        }

        else if (_alignmentPoints + alteredAmount <= 0)
        {
            FirstTimeAlignmentChange(alignment);
            OnAlignmentSliderDown(_alignmentPoints = Mathf.Abs(_alignmentPoints + alteredAmount));
            return;
        }

        RegularAlignmentChange(alteredAmount);
    }

    void FirstTimeAlignmentChange(AlignmentType alignment)
    {
        _currentAlignmentIndex = 0;
        _currentAlignment = alignment;
        _playerChange.SetAlignmentItemArrays(alignment);
    }

    private void OnAlignmentReverse(float alteredAmount)
    {
        _currentAlignment = _currentAlignment == AlignmentType.Good ? AlignmentType.Evil : AlignmentType.Good;
        _alignmentPoints = Mathf.Abs(_alignmentPoints + alteredAmount);
        OnAlignmentReversEvent?.Invoke(_currentAlignment);

        CalculateSliderQueue(0);
        CalculateSliderQueue(_alignmentPoints);
    }

    void OnAlignmentSliderDown(float target)
    {
        if (_currentAlignmentIndex > 0)
            _currentAlignmentIndex--;

        CalculateSliderQueue(target, true);
    }

    void OnAlignmentSliderUp(float target, bool firstChange = false)
    {
        if (_currentAlignmentIndex < 2 && !firstChange)
            _currentAlignmentIndex++;

        CalculateSliderQueue(target, true);
    }

    private void OnSliderChangeItems()
    {
        _playerChange.OnItemChange(_currentAlignmentIndex, _currentAlignment);
    }

    private void CalculateSliderQueue(float change, bool withChange = false)
    {
        if (CurrentAlignment == AlignmentType.Neutral)
        {
            float neutralValueToQueue = ((0.375f + ((1f / 4f)) * change ));
            _alignmentCanvas.EnqueueSliderTarget(neutralValueToQueue, withChange);
            
            return;
        }


        float valueToQueue = (((1f / 6f) * (_currentAlignmentIndex + 1))) + ((1f / 6f) * (change));

        if (CurrentAlignment == AlignmentType.Good)
            valueToQueue += 0.5f;

        else if (CurrentAlignment == AlignmentType.Evil)
        {
            valueToQueue = 0.5f - valueToQueue;
        }
            
        _alignmentCanvas.EnqueueSliderTarget(valueToQueue, withChange);
    }
}