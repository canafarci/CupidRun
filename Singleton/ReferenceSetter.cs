using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ReferenceObject
{
    FemaleHead,
    MaleHead,
    CupidHand,
    CoupleHolder,
    CoupleMidPoint

}

public class ReferenceSetter : MonoBehaviour
{
    [SerializeField] ReferenceObject _bodyPart;
    void Awake()
    {
        SwitchAndSetReference();
    }

    private void SwitchAndSetReference()
    {
        switch (_bodyPart)
        {
            case (ReferenceObject.FemaleHead):
                GameManager.Instance.References.FemaleHead = this.gameObject;
                break;
            case (ReferenceObject.MaleHead):
                GameManager.Instance.References.MaleHead = this.gameObject;
                break;
            case (ReferenceObject.CupidHand):
                GameManager.Instance.References.CupidHand = this.gameObject;
                break;
            case (ReferenceObject.CoupleHolder):
                GameManager.Instance.References.CoupleHolder  = this.gameObject;
                break;
            case (ReferenceObject.CoupleMidPoint):
                GameManager.Instance.References.CoupleMidPoint = this.gameObject;
                break;
            default:
                break;
        }
    }
}