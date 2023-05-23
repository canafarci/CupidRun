using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlignmentSlider : MonoBehaviour
{
    [SerializeField] Image _sliderImage;
    public static event Action OnSliderChange;

    public IEnumerator MoveSlider(float target, bool withChange = false)
    {
        if (target > _sliderImage.fillAmount)
        {
            while (target > _sliderImage.fillAmount)
            {
                yield return new WaitForSecondsRealtime(0.01f);
                _sliderImage.fillAmount += 0.01f;
            }
        }
        else
        {
            while (target < _sliderImage.fillAmount)
            {
                yield return new WaitForSecondsRealtime(0.01f);
                _sliderImage.fillAmount -= 0.01f;
            }
        }
        
        if (withChange)
        {
            yield return new WaitForSeconds(0.02f);
            OnSliderChange?.Invoke();
        }
            
    }
}
