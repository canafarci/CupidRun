using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageFill : MonoBehaviour
{
    Image _image;

    private void Awake() => _image = GetComponent<Image>();

    private void OnEnable() => StartCoroutine(FillImage());

    IEnumerator FillImage()
    {
        for (float i = 0; i < 0.33f; i += Time.deltaTime)
        {
            _image.fillAmount = i;
            yield return new WaitForSeconds(Time.deltaTime * 4f);
        }
    }
}
