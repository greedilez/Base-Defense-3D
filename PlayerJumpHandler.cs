using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerJumpHandler : MonoBehaviour
{
    private Rigidbody _rigidbody;

    [SerializeField] private KeyCode _targetButtonToJump = KeyCode.Space;

    [SerializeField] private float _jumpForce = 10;

    public bool IsGrounded{ get; private set; }

    private void Awake() {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update() {
        WaitForTargetButtonPress();
    }

    private void FixedUpdate() => AdjustIsGroundedState();

    private void AdjustIsGroundedState() {
        float rayLength = 1f;
        float yOffset = 0.9f;
        Vector3 offset = new Vector3(0, yOffset, 0);
        IsGrounded = Physics.Raycast(transform.position + offset, -transform.up, rayLength);
    }

    private void WaitForTargetButtonPress() {
        if (Input.GetKeyDown(_targetButtonToJump) && IsGrounded) {
            if (PlayerDeathHandler.Instance.IsPlayerAlive) {
                Jump();
            }
        }
    }

    private void Jump() {
        _rigidbody.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
    }
}
