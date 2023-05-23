using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour
{
    [SerializeField] AudioClip _clip;
    public IEnumerator ThrowObject(GameObject thrownObject, ReferenceObject bodyPart, GameObject _vfx)
    {
        Transform throwTarget = bodyPart == ReferenceObject.FemaleHead ? GameManager.Instance.References.FemaleHead.transform : GameManager.Instance.References.MaleHead.transform;
        thrownObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        thrownObject.transform.position = GameManager.Instance.References.CupidHand.transform.position;

        thrownObject.transform.parent = GameManager.Instance.References.CupidHand.transform;

        GameManager.Instance.AnimationManager.CupidAnimator.SetLayerWeight(1, 1);
        GameManager.Instance.AudioManager.PlaySFX(_clip);
        GameManager.Instance.AnimationManager.CupidAnimator.Play(AnimationStrings.Throw);

        float animationTime = GameManager.Instance.AnimationManager.GetAnimationLength(AnimationStrings.Throw, GameManager.Instance.AnimationManager.CupidAnimator);

        yield return new WaitForSeconds(animationTime / 3f);
        StartCoroutine(Throw(thrownObject, bodyPart, _vfx));
        yield return new WaitForSeconds(0.01f);
        StartCoroutine(DelayedResetWeights((2 * animationTime) / 3f));

             


    }

    IEnumerator Throw(GameObject thrownObject, ReferenceObject bodyPart, GameObject _vfx)
    {
        Transform throwTarget = bodyPart == ReferenceObject.FemaleHead ? GameManager.Instance.References.FemaleHead.transform : GameManager.Instance.References.MaleHead.transform;
        thrownObject.transform.parent = null;

        for (float x = 0; x < 1f; x += Time.deltaTime * 2f)
        {
            thrownObject.transform.position = Vector3.Slerp(thrownObject.transform.position, throwTarget.position, x);

            if (Vector3.Distance(thrownObject.transform.position, throwTarget.position) < 0.01f)
            {
                GameObject fx = Instantiate(_vfx, throwTarget.position, _vfx.transform.rotation, throwTarget);

                Destroy(fx, 5f);

                Destroy(thrownObject);
                
                yield break;
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    IEnumerator DelayedResetWeights(float time)
    {
        yield return new WaitForSeconds(time);
        GameManager.Instance.AnimationManager.CupidAnimator.SetLayerWeight(1, 0);

    }
}
