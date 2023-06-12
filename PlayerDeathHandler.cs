using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDeathHandler : MonoBehaviour
{
    public UnityEvent OnPlayerCatched;

    public static PlayerDeathHandler Instance;

    [SerializeField] private bool _isPlayerAlive = true;

    public bool IsPlayerAlive{ get => _isPlayerAlive; }

    private void Awake() {
        Instance = this;
    }

    public void PlayerDeath() {
        if (_isPlayerAlive) {
            OnPlayerCatched.Invoke();
            _isPlayerAlive = false;
        }
    }
}
