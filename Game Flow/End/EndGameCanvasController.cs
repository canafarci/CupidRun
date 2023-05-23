using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameCanvasController : MonoBehaviour
{
    [SerializeField] CanvasGroup _canvasGroup;
    [SerializeField] GameObject _canvas;

    public IEnumerator EndGameCanvasBehaviour()
    {
        yield return new WaitForSeconds(5f);
        _canvas.SetActive(true);

        while (_canvasGroup.alpha < 1f)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            _canvasGroup.alpha += Time.deltaTime;
        }
    }
}
