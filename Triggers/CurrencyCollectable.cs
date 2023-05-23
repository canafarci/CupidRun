using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyCollectable : Collectable, ICollectable
{
    public static event Action<int> OnCurrencyChanged;

    public override void OnCollected()
    {   
        base.OnCollected();

        if (_vfx != null)
        {
            GameObject vfxObject = Instantiate(_vfx, transform.position, _vfx.transform.rotation);
            Destroy(vfxObject, 5f);
            Destroy(this.gameObject);
        }

        OnCurrencyChanged?.Invoke((int)_increaseAmount);
    }
}
