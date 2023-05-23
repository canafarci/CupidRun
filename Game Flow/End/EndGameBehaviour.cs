using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameBehaviour : MonoBehaviour
{
    [SerializeField] Transform _targetTransform;
    EndGameCanvasController _canvasController;
    protected SplineFollower _splineFollower;

    protected virtual void Awake()
    {
        _splineFollower = transform.GetComponentInParent<SplineFollower>();
        _canvasController = FindObjectOfType<EndGameCanvasController>();
    }
    
    protected void DisablePathFollower() => _splineFollower.enabled = false;
    protected void EnablePathFollower() => _splineFollower.enabled = true;

    protected virtual IEnumerator MoveToPosition(float speed)
    {
        while (Vector3.Distance(transform.position, _targetTransform.position) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetTransform.position, Time.deltaTime * speed);
            yield return new WaitForSeconds(Time.deltaTime );
        }
    }

    protected IEnumerator ResetLocalXPosition()
    {
        for (float x = 0; x < 1f; x += Time.deltaTime)
        {
            Vector3 resetPos = transform.GetChild(0).localPosition;
            resetPos.x = 0;

            transform.GetChild(0).localPosition = Vector3.Lerp(transform.GetChild(0).localPosition, resetPos, x);

            yield return new WaitForSeconds(Time.deltaTime * 3f);
        }
    }

    protected void EndGameCanvasRoutine()
    {
        StartCoroutine(_canvasController.EndGameCanvasBehaviour());
    }
}