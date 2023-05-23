using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class MultiplyCurrencySlider : MonoBehaviour
{
    Saver _saver;
    [SerializeField] TextMeshProUGUI _text;
    float _value;

    private void Awake()
    {
        _saver = FindObjectOfType<Saver>();
        _value = _saver.GetInt(PrefKeys.Currency);
    } 

    public void OnSliderPass(int multiplier)
    {
        float multipliedAmount = multiplier * _value;
        _text.text = multipliedAmount.ToString();
    }
}
