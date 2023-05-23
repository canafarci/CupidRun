using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndFX : MonoBehaviour
{
    [SerializeField] GameObject _goodVFX, _badVFX, _confettiFX;
    [SerializeField] AudioClip _kissClip, _punchClip;

    public void PlayBadFX() => PlayFX(_punchClip, _badVFX);
    public void PlayGoodFX() => PlayFX(_kissClip, _goodVFX);
    public void ActivateConfetti() => _confettiFX.SetActive(true);

    private void PlayFX(AudioClip clip, GameObject vfx)
    {
        GameObject fx = Instantiate(vfx,
                                    GameManager.Instance.References.CoupleMidPoint.transform.position + vfx.transform.position,
                                    vfx.transform.rotation,
                                    GameManager.Instance.References.CoupleMidPoint.transform);
        Destroy(fx, 5f);

        if (clip != null)
            GameManager.Instance.AudioManager.PlaySFX(clip);
    }
}
