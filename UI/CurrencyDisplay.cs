using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrencyDisplay : MonoBehaviour
{
    TextMeshProUGUI _currencyText;

    private void Awake()
    {
        _currencyText = GetComponent<TextMeshProUGUI>();
    }

    // private void Start() => _currencyText.text = GameManager.Instance.Saver.GetInt(PrefKeys.Currency).ToString();

    public void OnCurrencyChange(int amount)
    {
        _currencyText.text = amount.ToString();
    }
}
