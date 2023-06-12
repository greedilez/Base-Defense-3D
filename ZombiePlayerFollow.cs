using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class ZombiePlayerFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private NavMeshAgent _navMeshAgent;

    [SerializeField] private ZombieHealthHandler _zombieHealthHandler;

    private float _minimalSpeed = 1f;

    private float _maximalSpeed = 3.5f;

    private void Awake() {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _target = GameObject.FindGameObjectWithTag("Player").transform;
        SetRandomSpeed();
    }

    private void SetRandomSpeed() => _navMeshAgent.speed = Random.Range(_minimalSpeed, _maximalSpeed);

    private void FixedUpdate() {
        FollowTargetPlayer();
    }

    private void FollowTargetPlayer() {
        if (!_zombieHealthHandler.IsDead && PlayerDeathHandler.Instance.IsPlayerAlive) {
            _navMeshAgent.SetDestination(_target.position);
        }
        else _zombieHealthHandler.StopAgent();
    }
}
