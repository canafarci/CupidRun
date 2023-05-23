using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderChange : MonoBehaviour
{
    [SerializeField] Image _fillImage;
    [SerializeField] TextMeshProUGUI _text;
    
    public void ChangeSlider(Sprite sprite, string text)
    {
        _fillImage.sprite = sprite;
        _text.text = text;
    }
    
}
