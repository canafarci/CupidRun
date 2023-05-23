using System.Collections;
using UnityEngine;

public class AlignmentCollectable : Collectable, ICollectable
{
    AlignmentCounter _alignmentCounter;
    [SerializeField] ReferenceObject _throwTarget;
    Thrower _thrower;
    [SerializeField] AudioClip _clip;

    protected override void Awake()
    {
        base.Awake();
        _alignmentCounter = FindObjectOfType<AlignmentCounter>();
        _thrower = FindObjectOfType<Thrower>();
    }
    public override void OnCollected()
    {
        base.OnCollected();

        //handle alignment increase
        GameManager.Instance.AnimationManager.EnqueueRoutine(_thrower.ThrowObject(this.gameObject, _throwTarget, _vfx));
        GameManager.Instance.AnimationManager.EnqueueRoutine(AlignmentAsync());

        if (_clip != null)
            GameManager.Instance.AudioManager.PlaySFX(_clip);
    }

    IEnumerator AlignmentAsync()
    {
        yield return null;
        _alignmentCounter.OnAlignmentChange(_alignmentType, _increaseAmount);
    }
}
