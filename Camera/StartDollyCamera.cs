using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDollyCamera : MonoBehaviour
{
    CinemachineVirtualCamera _cam;
    CinemachineTrackedDolly _dollyCam;
    [SerializeField] float _speed;

    private void Awake()
    {
        _cam = GetComponent<CinemachineVirtualCamera>();
        _dollyCam = _cam.GetCinemachineComponent<CinemachineTrackedDolly>();
    }

    private void Start()
    {
        StartCoroutine(StartCamAnimation());
    }

    private IEnumerator StartCamAnimation()
    {
        while (_dollyCam.m_PathPosition < 1f)
        {
            _dollyCam.m_PathPosition += 0.005f * _speed;
            yield return new WaitForSecondsRealtime(0.1f);
        }

        GameManager.Instance.CameraController.ActivateCamera(CameraStrings.RunCamera);
    }


}
