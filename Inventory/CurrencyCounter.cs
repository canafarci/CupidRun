using UnityEngine;

public class CurrencyCounter : MonoBehaviour
{
    public int CurrencyAmount => _currencyAmount;

    int _currencyAmount;
    CurrencyDisplay _currencyDisplay;
    Saver _saver;

    private void OnEnable() => CurrencyCollectable.OnCurrencyChanged += OnCurrencyChange;
    private void OnDisable() => CurrencyCollectable.OnCurrencyChanged -= OnCurrencyChange;

    private void Awake()
    {
        _saver = FindObjectOfType<Saver>();
        _currencyDisplay = FindObjectOfType<CurrencyDisplay>();
    }
    private void Start()
    {
        _currencyAmount = 0;
        //if (_saver.HasKey(PrefKeys.Currency))
        //    _currencyAmount = _saver.GetInt(PrefKeys.Currency);
    }

    public void OnCurrencyChange(int change)
    {
        _currencyAmount += change;
        _saver.SaveInt(PrefKeys.Currency, _currencyAmount);
        _currencyDisplay.OnCurrencyChange(_currencyAmount);
    }
}
