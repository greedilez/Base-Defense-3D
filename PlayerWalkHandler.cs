using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerWalkHandler : MonoBehaviour
{
    private Rigidbody _rigidbody;

    [SerializeField] private float _walkingSpeed = 1;

    [SerializeField] private float _runningSpeed = 7.5f;

    [SerializeField] private KeyCode _keyToRun = KeyCode.LeftShift;

    private float _currentSpeed;

    public bool IsWalking{ get; private set; }

    private void Awake() {
        _currentSpeed = _walkingSpeed;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        ApplySpeed();
        ChangeSpeedOnRun();
        UpdateIsWalkingState();
    }
    
    private void ApplySpeed() {
        if (PlayerDeathHandler.Instance.IsPlayerAlive) {
            Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            Vector3 finalDirection = transform.TransformDirection(direction * _currentSpeed);
            _rigidbody.AddForce(finalDirection - new Vector3(_rigidbody.velocity.x, 0, _rigidbody.velocity.z), ForceMode.VelocityChange);
        }
    }

    private void ChangeSpeedOnRun() {
        _currentSpeed = Input.GetKey(_keyToRun) ? _runningSpeed : _walkingSpeed;
    }

    private void UpdateIsWalkingState() => IsWalking = (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0);
}
