using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class ZombieHealthHandler : MonoBehaviour
{
    [SerializeField] private float _currentZombieHealth;

    public UnityEvent OnZombieDeath;

    private NavMeshAgent _agent;

    private float _lifetimeAfterDeath = 5;

    private void Awake() {
        _agent = GetComponent<NavMeshAgent>();
    }

    public bool IsDead{ get; private set; }

    public void DischargeZombieHealth(float valueToDischarge) {
        if (!IsDead) {
            if ((_currentZombieHealth - valueToDischarge) <= 0) {
                Death();
            }
            else _currentZombieHealth -= valueToDischarge;
        }
    }

    private void Death() {
        Destroy(gameObject, _lifetimeAfterDeath);
        _currentZombieHealth = 0;
        OnZombieDeath.Invoke();
        IsDead = true;
        KilledZombiesAmount.Instance.OnZombieKilled.Invoke();
        StopAgent();
    }

    public void StopAgent() {
        if (!_agent.isStopped) {
            _agent.velocity = Vector3.zero;
            _agent.speed = 0;
            _agent.isStopped = true;
        }
    }
}
