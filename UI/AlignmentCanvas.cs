using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlignmentCanvas : MonoBehaviour
{
    AlignmentSlider _alignmentSlider;

    //public Queue<IEnumerator> Queue { get { return _queue;} }
    Queue<IEnumerator> _queue =  new Queue<IEnumerator>();
    Coroutine _queueRoutine = null;

    private void Awake() => _alignmentSlider = GetComponent<AlignmentSlider>();
    public void EnqueueSliderTarget(float target, bool withChange = false)
    {
        _queue.Enqueue(_alignmentSlider.MoveSlider(target, withChange));

        if (_queueRoutine == null)
            _queueRoutine = StartCoroutine(ExecuteQueue());
    } 

    private IEnumerator ExecuteQueue()
    {
        while (_queue.Count > 0)
        {
            yield return StartCoroutine(_queue.Dequeue());
        }
        _queueRoutine = null;
    }
}
