using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] public CameraState CameraState;
    [SerializeField] private GameObject _fpsCamera;
    [SerializeField] private GameObject _tpsCamera;
    [SerializeField] private InputManager _inputManager;

    public Action OnChangePerspective;

    private void Start()
    {
        _inputManager.OnChangePOV += SwitchCamera;
    }

    public void SetFPSClampedCamera(bool isClamped, Vector3 playerRotation)
    {
        if (isClamped)
        {
            _fpsCamera.GetComponent<CinemachinePanTilt>().PanAxis.Range = new Vector2(playerRotation.y - 45, playerRotation.y + 45);
            _fpsCamera.GetComponent<CinemachinePanTilt>().PanAxis.Wrap = false;
        }
        else
        {
            _fpsCamera.GetComponent<CinemachinePanTilt>().PanAxis.Range = new Vector2(-180, 180);
            _fpsCamera.GetComponent<CinemachinePanTilt>().PanAxis.Wrap = true;
        }
    }

    private void SwitchCamera()
    {
        OnChangePerspective();
        if (CameraState == CameraState.ThirdPerson)
        {
            CameraState = CameraState.FirstPerson;
            _tpsCamera.SetActive(false);
            _fpsCamera.SetActive(true);
        }
        else
        {
            CameraState = CameraState.ThirdPerson;
            _tpsCamera.SetActive(true);
            _fpsCamera.SetActive(false);
        }
    }

    public void SetTPSFieldOfView(float fieldOfView)
    {
        _tpsCamera.GetComponent<CinemachineCamera>().Lens.FieldOfView = fieldOfView;
    }

    private void OnDestroy()
    {
        _inputManager.OnChangePOV -= SwitchCamera;
    }
}