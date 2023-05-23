using System;
using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameStart : MonoBehaviour
{
    SplineFollower[] splineFollowers;
    [SerializeField] float _defaultSpeed;
    [SerializeField] GameObject _startPrompt;

    public static event Action OnGameStart;

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            foreach (SplineFollower _sf in FindObjectsOfType<SplineFollower>())
            {
                _sf.followSpeed = _defaultSpeed;
            }

            OnGameStart?.Invoke();

            GameManager.Instance.AnimationManager.CupidAnimator.Play("catwalk");
            this.enabled = false;
        }
    }


}
