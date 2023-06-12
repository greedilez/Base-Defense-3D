using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomingHandler : MonoBehaviour
{
    [SerializeField] private AimingAnimationHandler _aimingAnimationHandler;

    [SerializeField] private Animator _cameraAnimator;

    private void FixedUpdate() => SetZoomingAnimationState();

    private void SetZoomingAnimationState() => _cameraAnimator.SetBool("IsAiming", _aimingAnimationHandler.IsAiming);
}
