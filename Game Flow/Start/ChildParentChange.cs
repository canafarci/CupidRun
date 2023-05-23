using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildParentChange : MonoBehaviour
{
    public void NullParent()
    {
        transform.parent = null;
    }

    public void AttachToParent(Transform parent)
    {
        transform.parent = parent;
    }
}
