using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerRotationHandler : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 5;

    private Rigidbody _rigidbody;

    private void Awake() => _rigidbody = GetComponent<Rigidbody>();

    private void Update() => ApplyRotation();

    private void ApplyRotation() {
        if (PlayerDeathHandler.Instance.IsPlayerAlive && !PauseHandler.Instance.IsPaused) {
            float horizontal = Input.GetAxis("Mouse X");
            Quaternion targetRotation = Quaternion.Euler(0, horizontal * _rotationSpeed, 0);
            _rigidbody.MoveRotation(_rigidbody.rotation * targetRotation);
        }
    }

    public void LookAt(Transform target) => transform.LookAt(target);
}
