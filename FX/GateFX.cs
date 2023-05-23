using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateFX : MonoBehaviour
{
    [SerializeField] string _animationName;

    [SerializeField] GameObject _fx;
    [SerializeField] AudioClip _audioClip;

    public void PlayFX()
    {
        if (_animationName != null)
            GameManager.Instance.AnimationManager.CupidAnimator.Play(_animationName);

        if (_audioClip != null)
            GameManager.Instance.AudioManager.PlaySFX(_audioClip);

        GameObject fx = Instantiate(_fx, GameManager.Instance.References.CoupleMidPoint.transform.position, _fx.transform.rotation, GameManager.Instance.References.CoupleMidPoint.transform);

        Destroy(fx, 5f);
    }
}
