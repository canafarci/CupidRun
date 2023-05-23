using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPositioner : MonoBehaviour
{
    [SerializeField] Transform _targetTransform, _targetParent;
    ChildParentChange _childParentChange;

    private void Awake()
    {
        _childParentChange = GetComponent<ChildParentChange>();
    }

    private void Start()
    {
        _childParentChange.NullParent();
    }

    public IEnumerator RotateValentine()
    {
        for (float i = 0; i < 1f; i += (Time.deltaTime / 5f))
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, _targetTransform.localRotation, i);
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
    public IEnumerator MoveValentine()
    {
        _childParentChange.AttachToParent(_targetParent);

        while (Vector3.Distance(transform.localPosition, _targetTransform.localPosition) > 0.01f)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, _targetTransform.localPosition, 2f * Time.deltaTime);
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
