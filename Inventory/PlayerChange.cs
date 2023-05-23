using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PlayerChange : MonoBehaviour
{
    [SerializeField] PlayerInventory _playerInventory;

    GameObject[] _currentModels;
    string[] _currentTexts;
    Sprite[] _currentSliderSprites;

    GameObject _currentActiveModel;

    SliderChange _sliderChange;

    private void Awake() => _sliderChange = FindObjectOfType<SliderChange>();

    private void OnEnable()
    {
        AlignmentCounter.OnAlignmentReversEvent += OnAlignmentReverse;
        AnimationManager.OnChangeAnimation += OnChangeAnimation;
    }
    private void OnDisable() 
    {
        AlignmentCounter.OnAlignmentReversEvent -= OnAlignmentReverse;
        AnimationManager.OnChangeAnimation -= OnChangeAnimation;
    }

    private void Start() => _currentActiveModel = Instantiate(_playerInventory.StartingModel, transform);

    public void OnAlignmentReverse(AlignmentType alignment)
    {
        SetAlignmentItemArrays(alignment);
        OnItemChange(0, alignment);
    }

    public void SetAlignmentItemArrays(AlignmentType alignment)
    {
        _currentModels = alignment == AlignmentType.Good ? _playerInventory.GoodPlayerModels : _playerInventory.EvilPlayerModels;
        _currentTexts = alignment == AlignmentType.Good ? _playerInventory.GoodSliderTexts : _playerInventory.EvilSliderTexts;
        _currentSliderSprites = alignment == AlignmentType.Good ? _playerInventory.GoodSliders : _playerInventory.EvilSliders;
    }

    public void OnItemChange(int index, AlignmentType alignment)
    {
        Destroy(_currentActiveModel);
        _currentActiveModel = Instantiate(_currentModels[index], transform);
        _sliderChange.ChangeSlider(_currentSliderSprites[index], _currentTexts[index]);

        GameManager.Instance.AnimationManager.EnqueueAnimation(AnimatorEnums.Cupid, _playerInventory.ChangeAnimationString, true);
    }

    void OnChangeAnimation(AlignmentType alignment)
    {
        GameObject _vfx = Instantiate(_playerInventory.ChangeVFX[alignment == AlignmentType.Good ? 0 : 1], transform);
        GameManager.Instance.AudioManager.PlaySFX(_playerInventory.TransformSFX);
        Destroy(_vfx, 5f);
    }
}