using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotationHandler : MonoBehaviour
{
    private float _currentXRotation = 0;

    private float _maximalXValue = 90;

    [SerializeField] private float _rotationSpeed;

    private void Update() {
        ApplyRotation();
    }

    private void ApplyRotation() {
        if (PlayerDeathHandler.Instance.IsPlayerAlive && !PauseHandler.Instance.IsPaused) {
            _currentXRotation += (_rotationSpeed * -Input.GetAxis("Mouse Y")) * Time.fixedDeltaTime;
            _currentXRotation = Mathf.Clamp(_currentXRotation, -_maximalXValue, _maximalXValue);
            transform.rotation = Quaternion.Euler(_currentXRotation, transform.eulerAngles.y, transform.eulerAngles.z);
        }
    }
}
